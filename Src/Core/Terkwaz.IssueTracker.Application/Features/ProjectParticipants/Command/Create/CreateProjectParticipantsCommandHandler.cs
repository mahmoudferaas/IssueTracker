using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Dtos;
using Terkwaz.IssueTracker.Application.Common.Interfaces;

namespace Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Create
{
    public class CreateProjectParticipantsCommandHandler : IRequestHandler<CreateProjectParticipantsCommand , Output>
    {
        private readonly IIssueTrackerDbContext _context;
        private readonly IMapper _mapper;

        public CreateProjectParticipantsCommandHandler(IIssueTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Output> Handle(CreateProjectParticipantsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var project = _context.Projects.Find(request.ProjectId);

                if (project == null)
                    return new Output { Status = false, ErrorMessage = "Project dosn't exist." };

                if (project.OwnerId != request.OwnerId)
                    return new Output { Status = false, ErrorMessage = "You aren't not owner of this project!." };

                foreach (var item in request.ParticipantEmails)
                {
                   var user = _context.Users.Where(a => a.Email == item).FirstOrDefault();
                   if(user != null)
                    {
                        _context.ProjectParticipants.Add(new Domain.Entities.ProjectParticipants
                        {
                            ParticipantId = user.Id,
                            ProjectId = request.ProjectId
                        });
                    }
                }

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