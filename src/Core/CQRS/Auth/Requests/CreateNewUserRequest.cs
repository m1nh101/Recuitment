using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Auth.Requests;

public class CreateNewUserRequest : IRequest<ActionResponse>
{
  public string Name { get; set; } = string.Empty;
  public string Username { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public int DepartmentId { get; } = 2;
  public string Role { get; set; } = string.Empty;
}