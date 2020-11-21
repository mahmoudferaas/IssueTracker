using FluentValidation;

namespace Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Update
{
    public class UpdateProjectParticipantsCommandValidators : AbstractValidator<UpdateProjectParticipantsCommand>
    {
        public UpdateProjectParticipantsCommandValidators()
        {
            RuleFor(x => x.ProjectId).NotEmpty().NotNull();
            RuleFor(x => x.ParticipantId).NotEmpty().NotNull();
        }
    }
}