using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Dtos;
using Terkwaz.IssueTracker.Application.Common.Interfaces;

namespace Terkwaz.IssueTracker.Application.Features.Projects.Commands.Delete
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Output>
    {
        private readonly IIssueTrackerDbContext _context;

        public DeleteProjectCommandHandler(IIssueTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<Output> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var project = _context.Projects.Find(request.Id);

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