using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Features.Projects.Commands.Create;
using Terkwaz.IssueTracker.Application.Features.Projects.Commands.Delete;
using Terkwaz.IssueTracker.Application.Features.Projects.Queries.GetAll;
using Terkwaz.IssueTracker.Presentation.Controllers;

namespace Admins.Service.Managment.Presentation.Controllers
{
    //[Authorize]
    public class ProjectsController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
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

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteProjectCommand command)
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

        [HttpPost("GetAllProjects")]
        public async Task<IActionResult> GetAll([FromBody] GetAllProjectsQuery query)
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