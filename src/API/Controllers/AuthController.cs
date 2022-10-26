using Core.CQRS.Auth.Login;
using Core.CQRS.Auth.Requests;
using Core.Entities.Users;
using Core.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
  private readonly IMediator _mediator;
	private readonly JwtHelper _jwt;

	public AuthController(IMediator mediator, JwtHelper jwt)
	{
		_mediator = mediator;
		_jwt = jwt;
	}

	[HttpGet]
	[Route("roles")]
	//[Authorize(Roles = "HR")]
	public async Task<IActionResult> GetRoles()
	{
		var request = new GetAllRoleRequest();
		var response = await _mediator.Send(request);
		return Ok(response);
	}

	// [HttpPost]
	// [Route("users")]
	// public async Task<IActionResult> CreateNewUser([FromBody] CreateNewUserRequest request)
	// {
	// 	var response = await _mediator.Send(request);

	// 	if (response.StatusCode == System.Net.HttpStatusCode.OK)
	// 		return Ok(response);

	// 	return BadRequest(response);
	// }

	[HttpPost]
	[Route("login")]
	public async Task<IActionResult> Login([FromBody] LoginRequest request)
	{
		var response = await _mediator.Send(request);

		if(response.StatusCode == System.Net.HttpStatusCode.BadGateway)
			return BadRequest(response);

		var user = (User)response.Data!;

		_jwt.SetUser(user);

		var token = await _jwt.GenerateJwtToken();

		Response.Cookies.Append("token", token, new CookieOptions {
			HttpOnly = true,
			SameSite = SameSiteMode.None,
			Secure = true
		});

		return Ok(new
		{
			user.Name,
			user.Email
		});
	}

	[HttpPost]
	[Authorize]
	[Route("logout")]
	public IActionResult Logout()
	{
		Response.Cookies.Delete("token");
		return NoContent();
	}
}