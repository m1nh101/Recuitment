using Core.CQRS.Auth.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
  private readonly IMediator _mediator;

	public EmployeeController(IMediator mediator)
	{
		_mediator = mediator;
	}

  [HttpGet]
  public async Task<IActionResult> GetEmployee()
  {
    var request = new GetAllEmployeeRequest();
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpGet]
  [Route("reviewers")]
  public async Task<IActionResult> GetReviewer()
  {
    var request = new GetAllReviewerRequest();
    var response = await _mediator.Send(request);
    return Ok(response);
  }
}