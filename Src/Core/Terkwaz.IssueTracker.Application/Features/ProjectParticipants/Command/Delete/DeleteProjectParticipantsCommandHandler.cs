using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Dtos;
using Terkwaz.IssueTracker.Application.Common.Interfaces;

namespace Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Delete
{
    public class DeleteProjectParticipantsCommandHandler : IRequestHandler<DeleteProjectParticipantsCommand , Output>
    {
        private readonly IIssueTrackerDbContext _context;

        public DeleteProjectParticipantsCommandHandler(IIssueTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<Output> Handle(DeleteProjectParticipantsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var project = _context.Projects.Find(request.Id);

                if (project == null)
                    return new Output { Status = false, ErrorMessage = "Project dosn't exist." };

                _context.Projects.Remove(project);

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