using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Terkwaz.IssueTracker.Presentation.Controllers
{
	[Authorize]
	public class BaseController : ControllerBase
	{
		private readonly IMediator _mediator;
		protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();
	}
}