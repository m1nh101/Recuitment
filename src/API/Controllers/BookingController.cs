using Core.CQRS.Bookings.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingController : ControllerBase
{
	private readonly IMediator _mediator;

	public BookingController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var request = new GetAllBookingRequest();
		var response = await _mediator.Send(request);

		return Ok(response);
	}

	[HttpPost]
	public async Task<IActionResult> CreateBooking([FromBody] CreateNewBookingRequest request)
	{
		var response = await _mediator.Send(request);

		if(response.StatusCode == System.Net.HttpStatusCode.OK)
			return Ok(response);

		return NotFound(response);
	}
}