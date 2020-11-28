using FluentValidation;

namespace Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Create
{
    public class CreateProjectParticipantsCommandValidators : AbstractValidator<CreateProjectParticipantsCommand>
    {
        public CreateProjectParticipantsCommandValidators()
        {
            RuleFor(x => x.ProjectId).NotEmpty().NotNull();
            RuleFor(x => x.ParticipantEmails).NotEmpty().NotNull();
        }
    }
}