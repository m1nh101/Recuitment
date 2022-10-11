using Core.CQRS.Auth.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
  private readonly IMediator _mediator;

	public AuthController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	[Route("roles")]
	public async Task<IActionResult> GetRoles()
	{
		var request = new GetAllRoleRequest();
		var response = await _mediator.Send(request);
		return Ok(response);
	}
}