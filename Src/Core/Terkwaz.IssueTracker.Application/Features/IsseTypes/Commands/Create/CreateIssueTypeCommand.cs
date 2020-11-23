using MediatR;
using Terkwaz.IssueTracker.Application.Common.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.IsseTypes.Commands.Create
{
    public class CreateIssueTypeCommand : IRequest<Output>
    {
        public string Name { get; set; }
    }
}