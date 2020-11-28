using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Helpers;
using Terkwaz.IssueTracker.Application.Common.Interfaces;
using Terkwaz.IssueTracker.Application.Features.Issues.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.Issues.Queries.GetIssuesByProject
{
    public class GetIssuesByProjectQueryHandler : IRequestHandler<GetIssuesByProjectQuery, List<IssueOutputDto>>
    {
        private readonly IIssueTrackerDbContext _context;
        private readonly IMapper _mapper;

        public GetIssuesByProjectQueryHandler(IIssueTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<IssueOutputDto>> Handle(GetIssuesByProjectQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var issues = await _context.Issues.WhereIf(request.AssigneeId != null , x => x.AssigneeId == request.AssigneeId)
                              .Where(x => x.ProjectId == request.ProjectId).Include(a => a.IssueType).Include(a => a.Assignee).ToListAsync();

                return _mapper.Map<List<IssueOutputDto>>(issues);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}