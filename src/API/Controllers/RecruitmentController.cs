using Core.CQRS.Applications.Apply;
using Core.CQRS.Applications.Delete;
using Core.CQRS.Recruitments.Create;
using Core.CQRS.Recruitments.Delete;
using Core.CQRS.Recruitments.Query;
using Core.CQRS.Recruitments.Update;
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
		var request = new GetAllRecruitmentRequest();
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
	public async Task<IActionResult> PostRecruitment([FromBody] CreateRecruitmentRequest request)
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

  [HttpDelete]
  [Route("{recruitmentId:int}/applications/{id:int}")]
  public async Task<IActionResult> DeleteApplication([FromRoute] int recruitmentId, [FromRoute] int id)
  {
    var request = new DeleteApplicationRequest(recruitmentId, id);
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpPost]
  [Route("{id:int}/candidates")]
  public async Task<IActionResult> AddCandidate([FromRoute] int id,
    [FromBody] ApplyToRecruitmentRequest request)
  {
    var response = await _mediator.Send(request);

    if (response.StatusCode == System.Net.HttpStatusCode.OK)
      return Ok(response);

    return BadRequest(response);
  }

  // [HttpPatch]
  // [Route("{id:int}/candidates/{candidateId:int}")]
  // public async Task<IActionResult> UpdateCandidateFromRecruitment([FromRoute] int id,
  // 	[FromRoute] int candidateId,
  // 	[FromBody] UpdateCandidateRequest request)
  // {
  // 	if (candidateId != request.Id)
  // 		return BadRequest();

  // 	var response = await _mediator.Send(request);

  // 	if (response.StatusCode == System.Net.HttpStatusCode.OK)
  // 		return Ok(response);

  // 	return BadRequest(response);
  // }
}