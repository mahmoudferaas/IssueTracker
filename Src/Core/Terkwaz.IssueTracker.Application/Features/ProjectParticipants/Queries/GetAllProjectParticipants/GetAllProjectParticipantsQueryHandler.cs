using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Dtos;
using Terkwaz.IssueTracker.Application.Common.Interfaces;

namespace Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Queries.GetAllProjectParticipants
{
    public class GetAllProjectParticipantsQueryHandler : IRequestHandler<GetAllProjectParticipantsQuery , List<UserDto>>
    {
        private readonly IIssueTrackerDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProjectParticipantsQueryHandler(IIssueTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetAllProjectParticipantsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var participants = new List<UserDto>();

                var dbProjects = await _context.ProjectParticipants.Where(a=>a.ProjectId == request.ProjectId)
                    .Include(a => a.Participant).Include(a => a.Project).ToListAsync();

                foreach (var item in dbProjects)
                {
                    var user = _context.Users.Find(item.ParticipantId);

                    participants.Add(_mapper.Map<UserDto>(user));
                }

                return participants;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

   
    }

}
