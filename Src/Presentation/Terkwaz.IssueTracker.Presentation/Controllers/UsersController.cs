using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Features.Users.Comands.Create;
using Terkwaz.IssueTracker.Application.Features.Users.Comands.Login;
using Terkwaz.IssueTracker.Application.Features.Users.Queries.GetAll;
using Terkwaz.IssueTracker.Presentation.Controllers;

namespace Admins.Service.Managment.Presentation.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
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

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
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

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAll([FromBody] GetAllUsersQuery command)
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
    }
}