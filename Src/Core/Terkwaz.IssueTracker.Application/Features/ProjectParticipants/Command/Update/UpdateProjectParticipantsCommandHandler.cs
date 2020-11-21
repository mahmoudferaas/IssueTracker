using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Dtos;
using Terkwaz.IssueTracker.Application.Common.Interfaces;

namespace Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Update
{
    public class UpdateProjectParticipantsCommandHandler : IRequestHandler<UpdateProjectParticipantsCommand, Output>
    {
        private readonly IIssueTrackerDbContext _context;
        private readonly IMapper _mapper;

        public UpdateProjectParticipantsCommandHandler(IIssueTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Output> Handle(UpdateProjectParticipantsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _context.ProjectParticipants.Find(request.Id);

                if (entity == null)
                    return new Output { Status = false, ErrorMessage = "Entity dosn't exit." };

                _mapper.Map(request, entity);

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