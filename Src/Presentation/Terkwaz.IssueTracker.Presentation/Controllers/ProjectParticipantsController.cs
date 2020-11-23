using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Create;
using Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Delete;
using Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Update;
using Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Queries.GetAllProjectParticipants;
using Terkwaz.IssueTracker.Presentation.Controllers;

namespace Admins.Service.Managment.Presentation.Controllers
{
    //[Authorize]
    public class ProjectParticipantsController : BaseController
    {
        [HttpPost("CreateProjectParticipants")]
        public async Task<IActionResult> Create([FromBody] CreateProjectParticipantsCommand command)
        {
            try
            {
                var output = await Mediator.Send(command);

                return Ok(output);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut("UpdateProjectParticipants")]
        public async Task<IActionResult> Delete([FromBody] UpdateProjectParticipantsCommand command)
        {
            try
            {
                var output = await Mediator.Send(command);

                return Ok(output);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("DeleteProjectParticipants")]
        public async Task<IActionResult> Delete([FromBody] DeleteProjectParticipantsCommand command)
        {
            try
            {
                var output = await Mediator.Send(command);

                return Ok(output);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost("GetParticipantsOfProject")]
        public async Task<IActionResult> GetAll([FromBody] GetAllProjectParticipantsQuery query)
        {
            try
            {
                var output = await Mediator.Send(query);

                return Ok(output);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}