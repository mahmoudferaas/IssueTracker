using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Features.Issues.Commands.Create;
using Terkwaz.IssueTracker.Application.Features.Issues.Commands.Delete;
using Terkwaz.IssueTracker.Application.Features.Issues.Commands.Update;
using Terkwaz.IssueTracker.Application.Features.Issues.Queries.GetIssuesByProject;
using Terkwaz.IssueTracker.Presentation.Controllers;

namespace Admins.Service.Managment.Presentation.Controllers
{
    //[Authorize]
    public class IssuesController : BaseController
    {
        [HttpPost("CreateIssue")]
        public async Task<IActionResult> Create([FromBody] CreateIssueCommand command)
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

        [HttpPut("UpdateIssue")]
        public async Task<IActionResult> Update([FromBody] UpdateIssueCommand command)
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

        [HttpDelete("DeleteIssue")]
        public async Task<IActionResult> Delete([FromBody] DeleteIssueCommand command)
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

        [HttpPost("GetAllIssues")]
        public async Task<IActionResult> GetAll([FromBody] GetIssuesByProjectQuery query)
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