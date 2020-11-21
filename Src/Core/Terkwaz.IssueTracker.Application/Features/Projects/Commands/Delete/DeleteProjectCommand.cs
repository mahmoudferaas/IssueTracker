using MediatR;
using Terkwaz.IssueTracker.Application.Common.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.Projects.Commands.Delete
{
    public class DeleteProjectCommand : IRequest<Output>
    {
        public int Id { get; set; }
    }
}