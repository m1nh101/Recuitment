using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Auth.Requests;

public class ChangeUserRoleRequest : IRequest<ActionResponse>
{
  public string UserId { get; set; } = string.Empty;
  public string RoleId { get; set; } = string.Empty;
}