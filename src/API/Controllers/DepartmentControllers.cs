using Core.CQRS.Departments.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/departments")]
public class DepartmentControllers : ControllerBase
{
  private readonly IMediator _mediator;

	public DepartmentControllers(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<IActionResult> GetDepartments()
	{
		var request = new GetAllDepartmentsRequest();
		var response = await _mediator.Send(request);
		return Ok(response);
	}

	[HttpPost]
	public async Task<IActionResult> PostDepartment([FromBody] CreateNewDepartmentRequest request)
	{
		var response = await _mediator.Send(request);
		return Ok(response);
	}
}