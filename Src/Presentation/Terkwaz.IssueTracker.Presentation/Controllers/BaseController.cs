using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Terkwaz.IssueTracker.Presentation.Controllers
{
	public class BaseController : ControllerBase
	{
		private readonly IMediator _mediator;
		protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();
	}
}