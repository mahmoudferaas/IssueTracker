using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Dtos;
using Terkwaz.IssueTracker.Application.Common.Interfaces;

namespace Terkwaz.IssueTracker.Application.Features.Issues.Commands.Delete
{
    public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommand, Output>
    {
        private readonly IIssueTrackerDbContext _context;

        public DeleteIssueCommandHandler(IIssueTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<Output> Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var issue = _context.Issues.Find(request.Id);

                if (issue == null)
                    return new Output { Status = false, ErrorMessage = "issue dosn't exist." };

                _context.Issues.Remove(issue);

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