using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Dtos;
using Terkwaz.IssueTracker.Application.Common.Interfaces;
using Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Create;
using Terkwaz.IssueTracker.Domain.Entities;

namespace Terkwaz.IssueTracker.Application.Features.Projects.Commands.Create
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand,Output>
    {
        private readonly IIssueTrackerDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateProjectCommandHandler(IIssueTrackerDbContext context, IMapper mapper,IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Output> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _context.Users.Find(request.OwnerId);
                if(user == null)
                    return new Output { Status = false, ErrorMessage = "This owner dosn't exist in participants!." };

                var entity = _mapper.Map<Project>(request);

                _context.Projects.Add(entity);

                //_context.ProjectParticipants.Add(new Domain.Entities.ProjectParticipants { 
                //    ParticipantId = request.OwnerId,
                //    ProjectId = entity.Id
                //});

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Send(new CreateProjectParticipantsCommand
                {
                    OwnerId = request.OwnerId,
                    ProjectId = entity.Id,
                    ParticipantEmails = new List<string>(){ user.Email }
                });

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