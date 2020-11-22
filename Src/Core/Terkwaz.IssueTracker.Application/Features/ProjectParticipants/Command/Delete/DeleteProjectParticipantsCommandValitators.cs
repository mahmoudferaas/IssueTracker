using FluentValidation;

namespace Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Delete
{
    public class DeleteProjectParticipantsCommandValitators : AbstractValidator<DeleteProjectParticipantsCommand>
    {
        public DeleteProjectParticipantsCommandValitators()
        {
            RuleFor(x => x.ProjectId).NotEmpty().NotNull();
            RuleFor(x => x.OwnerId).NotEmpty().NotNull();
            RuleFor(x => x.ParticipantEmails).NotEmpty().NotNull();
        }
    }
}