using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Dtos;
using Terkwaz.IssueTracker.Application.Common.Helpers;
using Terkwaz.IssueTracker.Application.Common.Interfaces;
using Terkwaz.IssueTracker.Domain.Entities;

namespace Terkwaz.IssueTracker.Application.Features.Users.Comands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Output>
    {
        private readonly IIssueTrackerDbContext _context;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IIssueTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Output> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<User>(request);

                if (!string.IsNullOrEmpty(request.Password))
                    entity.PasswordHash = SecurityHelper.Encrypt(request.Password);

                _context.Users.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new Output { Status = true };
            }
            catch (System.Exception ex)
            {
                return new Output { Status = false , ErrorMessage = ex.Message };
                throw;
            }
        }
    }
}