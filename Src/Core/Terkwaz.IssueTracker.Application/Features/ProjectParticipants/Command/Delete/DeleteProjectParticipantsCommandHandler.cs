using MediatR;
using System.Linq;
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
                var project = _context.Projects.Find(request.ProjectId);

                if (project == null)
                    return new Output { Status = false, ErrorMessage = "Project dosn't exist." };

                if (project.OwnerId != request.OwnerId)
                    return new Output { Status = false, ErrorMessage = "You aren't not owner of this project!." };

                foreach (var item in request.ParticipantEmails)
                {
                    var user = _context.Users.Where(a => a.Email == item).FirstOrDefault();
                    if (user != null)
                    {
                        _context.ProjectParticipants.Remove(new Domain.Entities.ProjectParticipants
                        {
                            ParticipantId = user.Id,
                            ProjectId = request.ProjectId
                        });
                    }
                }

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