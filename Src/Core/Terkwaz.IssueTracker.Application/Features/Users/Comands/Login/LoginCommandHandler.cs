using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common;
using Terkwaz.IssueTracker.Application.Common.Helpers;
using Terkwaz.IssueTracker.Application.Common.Interfaces;
using Terkwaz.IssueTracker.Application.Features.Users.Comands.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.Users.Comands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginOutput>
    {
        private readonly IIssueTrackerDbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public LoginCommandHandler(IIssueTrackerDbContext context, IMapper mapper , IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public async Task<LoginOutput> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                    return await Task.FromResult<LoginOutput>(null);

                request.Password = SecurityHelper.HashText(request.Password);

                // check if user exists
                var userDB = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email && x.PasswordHash == request.Password);

                if (userDB == null)
                    return await Task.FromResult<LoginOutput>(null);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, userDB.Id.ToString())
                    }),
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                var tokenString = tokenHandler.WriteToken(token);
                
                var userDto = _mapper.Map<LoginOutput>(userDB);
                userDto.Token = tokenString;

                // authentication successful
                return userDto;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}