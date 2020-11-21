using FluentValidation;

namespace Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Create
{
    public class CreateProjectCommandValidators : AbstractValidator<CreateProjectParticipantsCommand>
    {
        public CreateProjectCommandValidators()
        {
            RuleFor(x => x.ProjectId).NotEmpty().NotNull();
            RuleFor(x => x.ParticipantEmails).NotEmpty().NotNull();
        }
    }
}