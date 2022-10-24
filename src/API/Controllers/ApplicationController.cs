
using Core.CQRS.Bookings.BookingInterview;
using Core.CQRS.Bookings.Cancel;
using Core.CQRS.Interviews;
using Core.CQRS.Interviews.Finnish;
using Core.CQRS.Interviews.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/applications")]
public class ApplicationController : ControllerBase
{
  private readonly IMediator _mediator;

  public ApplicationController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost]
  [Route("{id:int}/booking")]
	public async Task<IActionResult> CreateBooking([FromRoute] int id, [FromBody] BookingAnInterviewRequest request)
	{
		var response = await _mediator.Send(request);

		if(response.StatusCode == System.Net.HttpStatusCode.OK)
			return Ok(response);

		return NotFound(response);
	}

  [HttpDelete]
  [Route("{id:int}/booking")]
  public async Task<IActionResult> CancelInterview([FromRoute] int id)
  {
    var request = new CancelBookingRequest(id);
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpPatch]
  [Route("{id:int}/interview/start")]
  public async Task<IActionResult> StartInterview([FromRoute] int id)
  {
    var request = new StartInterviewRequest(id);
    var response = await _mediator.Send(request);

    return Ok(response);
  }

  [HttpPatch]
  [Route("{id:int}/interview/finish")]
  public async Task<IActionResult> FinishInterview([FromRoute] int id,
    [FromBody] FinishInterviewRequest request)
  {
    if (id != request.ApplicationId)
      return BadRequest(new { Message = "route id not match body id" });

    var response = await _mediator.Send(request);

    return Ok(response);
  }

  [HttpGet]
  public async Task<IActionResult> GetInterviewByReviewer()
  {
    var request = new GetInterviewByReviewerRequest();
    var response = await _mediator.Send(request);

    return Ok(request);
  }
}