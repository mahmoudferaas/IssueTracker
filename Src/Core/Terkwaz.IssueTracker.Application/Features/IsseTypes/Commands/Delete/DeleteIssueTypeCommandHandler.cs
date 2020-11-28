using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Dtos;
using Terkwaz.IssueTracker.Application.Common.Exceptions;
using Terkwaz.IssueTracker.Application.Common.Interfaces;

namespace Terkwaz.IssueTracker.Application.Features.IssueTypes.Commands.Delete
{
    public class DeleteIssueTypeCommandHandler : IRequestHandler<DeleteIssueTypeCommand, Output>
    {
        private readonly IIssueTrackerDbContext _context;

        public DeleteIssueTypeCommandHandler(IIssueTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<Output> Handle(DeleteIssueTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var issue = _context.IssueTypes.Find(request.Id);

                if (issue == null)
                    return new Output { Status = false, ErrorMessage = "issue dosn't exist." };

                var hasIssues = _context.Issues.Any(o => o.IssueTypeId == issue.Id);
                if (hasIssues)
                    throw new DeleteFailureException(nameof(IsseTypes), request.Id, "There are existing Issues associated with this issueType.");

                _context.IssueTypes.Remove(issue);

                await _context.SaveChangesAsync(cancellationToken);

                return new Output { Status = true };
            }
            catch (System.Exception ex)
            {
                return new Output { Status = false, ErrorMessage = ex.Message };
                throw;
            }
        }
    }
}