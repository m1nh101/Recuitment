using Core.CQRS.Candidates.Requests;
using Core.CQRS.Recruitments.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/recruitments")]
public class RecruitmentController : ControllerBase
{
	private readonly IMediator _mediator;

	public RecruitmentController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<IActionResult> GetRecruitments()
	{
		var request = new GetAllRecruitmentsRequest();
		var response = await _mediator.Send(request);
		return Ok(response);
	}

  [HttpGet]
  [Route("{id:int}")]
  public async Task<IActionResult> GetRecruitmentDetail([FromRoute] int id)
  {
    var request = new GetRecruitmentDetailRequest(id);
    var response = await _mediator.Send(request);

    if (response.StatusCode == System.Net.HttpStatusCode.OK)
      return Ok(response);

    return NotFound(response);
  }

  [HttpPost]
	public async Task<IActionResult> PostRecruitment([FromBody] CreateNewRecruitmentRequest request)
	{
		var response = await _mediator.Send(request);

		if (response.StatusCode == System.Net.HttpStatusCode.OK)
			return Ok(response);

		return BadRequest(response);
	}

	[HttpPatch]
	[Route("{id:int}")]
	public async Task<IActionResult> PatchRecruitment([FromRoute] int id,
		[FromBody] UpdateRecruitmentRequest request)
	{
		request.Id = id;
    var response = await _mediator.Send(request);

		if (response.StatusCode == System.Net.HttpStatusCode.OK)
			return Ok(response);

		return NotFound(response);
	}

	[HttpDelete]
	[Route("{id:int}")]
	public async Task<IActionResult> DeleteRecruitment([FromRoute] int id)
	{
		var request = new DeleteRecruitmentRequest(id);
    var response = await _mediator.Send(request);

    if (response.StatusCode == System.Net.HttpStatusCode.OK)
      return Ok(response);

    return NotFound(response);
  }
	
	[HttpPost]
	[Route("{id:int}/candidates")]
	public async Task<IActionResult> AddCandidate([FromRoute] int id,
		[FromBody] AddCandidateToRecruitmentRequest request)
	{
		request.RecruitmentId = id;
		var response = await _mediator.Send(request);

		if (response.StatusCode == System.Net.HttpStatusCode.OK)
			return Ok(response);

		return BadRequest(response);
	}
}