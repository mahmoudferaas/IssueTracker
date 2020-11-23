using MediatR;
using Terkwaz.IssueTracker.Application.Common.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.IsseTypes.Commands.Update
{
    public class UpdateIssueTypeCommand : IRequest<Output>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}