using FluentValidation;

namespace Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Delete
{
    public class DeleteProjectParticipantsCommandValitators : AbstractValidator<DeleteProjectParticipantsCommand>
    {
        public DeleteProjectParticipantsCommandValitators()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}