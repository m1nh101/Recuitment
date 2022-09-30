using Core.CQRS.Candidates.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/candidates")]
public class CandidateController : ControllerBase
{
	private readonly IMediator _mediator;

	public CandidateController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpPatch]
	[Route("{id:int}")]
	public async Task<IActionResult> UpdateCandidate([FromRoute] int id, [FromBody] UpdateCandidateRequest request)
	{
		request.Id = id;

		var response = await _mediator.Send(request);

		if(response.StatusCode == System.Net.HttpStatusCode.OK)
			return Ok(response);

		return NotFound(response);
	}
}