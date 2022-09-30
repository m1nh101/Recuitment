using Core.CQRS.Departments.Responses;
using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Departments.Requests;

public class CreateNewDepartmentRequest : IRequest<ActionResponse>
{
  public string Name { get; set; } = string.Empty;
  public string Location { get; set; } = string.Empty;
}