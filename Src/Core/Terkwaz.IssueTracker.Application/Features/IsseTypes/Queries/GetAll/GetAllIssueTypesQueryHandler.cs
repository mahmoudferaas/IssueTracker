using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Interfaces;
using Terkwaz.IssueTracker.Application.Features.IsseTypes.Dtos;
using Terkwaz.IssueTracker.Application.Features.Users.Comands.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.IssueTypes.Queries.GetAll
{
    public class GetAllIssueTypesQueryHandler : IRequestHandler<GetAllIssueTypesQuery, List<IssueTypesDto>>
    {
        private readonly IIssueTrackerDbContext _context;
        private readonly IMapper _mapper;

        public GetAllIssueTypesQueryHandler(IIssueTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<IssueTypesDto>> Handle(GetAllIssueTypesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var issueTypes = await _context.IssueTypes.ToListAsync();

                return _mapper.Map<List<IssueTypesDto>>(issueTypes);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}