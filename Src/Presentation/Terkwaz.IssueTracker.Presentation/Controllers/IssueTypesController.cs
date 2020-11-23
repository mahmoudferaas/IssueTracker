using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Features.IsseTypes.Commands.Create;
using Terkwaz.IssueTracker.Application.Features.IsseTypes.Commands.Update;
using Terkwaz.IssueTracker.Application.Features.IssueTypes.Commands.Delete;
using Terkwaz.IssueTracker.Application.Features.IssueTypes.Queries.GetAll;
using Terkwaz.IssueTracker.Presentation.Controllers;

namespace Admins.Service.Managment.Presentation.Controllers
{
    public class IssueTypeTypesController : BaseController
    {
        [HttpPost("CreateIssueType")]
        public async Task<IActionResult> Create([FromBody] CreateIssueTypeCommand command)
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

        [HttpPut("UpdateIssueType")]
        public async Task<IActionResult> Update([FromBody] UpdateIssueTypeCommand command)
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

        [HttpDelete("DeleteIssueType")]
        public async Task<IActionResult> Delete([FromBody] DeleteIssueTypeCommand command)
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

        [HttpPost("GetAllIssueTypes")]
        public async Task<IActionResult> GetAll([FromBody] GetAllIssueTypesQuery query)
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