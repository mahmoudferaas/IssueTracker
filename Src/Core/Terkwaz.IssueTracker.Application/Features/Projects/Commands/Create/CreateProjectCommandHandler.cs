using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.Projects.Commands.Create
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand,Output>
    {

        public Task<Output> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
        
    }
}