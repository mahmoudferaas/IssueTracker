using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Dtos;
using Terkwaz.IssueTracker.Application.Common.Interfaces;
using Terkwaz.IssueTracker.Domain.Entities;

namespace Terkwaz.IssueTracker.Application.Features.Issues.Commands.Create
{
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, Output>
    {
        private readonly IIssueTrackerDbContext _context;
        private readonly IMapper _mapper;

        public CreateIssueCommandHandler(IIssueTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Output> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var project = _context.Projects.Where(x=>x.Id == request.ProjectId).Include(a => a.Issues).FirstOrDefault();

                if (project == null)
                    return new Output { Status = false, ErrorMessage = "Project dosn't exist." };

                var entity = _mapper.Map<Issue>(request);

                entity.Id = await GetIssueId(project);

                await _context.SaveChangesAsync(cancellationToken);

                return new Output { Status = true };
            }
            catch (System.Exception ex)
            {
                return new Output { Status = false, ErrorMessage = ex.Message };
                throw;
            }
        }

        private async Task<string> GetIssueId(Project project)
        {
            var key = project.Key;
            int seq = project.Issues.Count() + 1;
            return $"{key}-{seq}";
        }
    }
}