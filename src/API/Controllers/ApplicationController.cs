using Core.CQRS.Applications.Detail;
using Core.CQRS.Applications.Update;
using Core.CQRS.Bookings.BookingInterview;
using Core.CQRS.Bookings.Cancel;
using Core.CQRS.Interviews;
using Core.CQRS.Interviews.Finnish;
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

  [HttpGet]
  [Route("{id:int}")]
  public async Task<IActionResult> GetDetail([FromRoute] int id)
  {
    var request = new GetApplicationDetailRequest(id);
    var response = await _mediator.Send(request);

    return Ok(response);
  }

  [HttpPatch]
  [Route("{id:int}")]
  public async Task<IActionResult> UpdateDetail([FromBody] UpdateApplicationRequest request)
  {
    var response = await _mediator.Send(request);
    return Ok(response);
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
    var _ = await _mediator.Send(request);
    return NoContent();
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
}