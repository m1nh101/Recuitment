using Core.CQRS.Positions.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/positions")]
public class PositionController : ControllerBase
{
  private readonly IMediator _mediator;

	public PositionController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<IActionResult> GetPositions()
	{
		var request = new GetAllPositionsRequest();
		var response = await _mediator.Send(request);
		return Ok(response);
	}
}