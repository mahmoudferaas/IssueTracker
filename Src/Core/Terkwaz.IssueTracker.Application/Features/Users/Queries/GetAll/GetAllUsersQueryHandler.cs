using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Interfaces;
using Terkwaz.IssueTracker.Application.Features.Users.Comands.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.Users.Queries.GetAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersOutput>
    {
        private readonly IIssueTrackerDbContext _context;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IIssueTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllUsersOutput> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _context.Users.ToListAsync();

                return _mapper.Map<GetAllUsersOutput>(users);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}