using Core.CQRS.Levels.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/levels")]
public class LevelController : ControllerBase
{
  private readonly IMediator _mediator;

	public LevelController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<IActionResult> GetLevels()
	{
		var request = new GetAllLevelsRequest();
		var response = await _mediator.Send(request);
		return Ok(response);
	}
}