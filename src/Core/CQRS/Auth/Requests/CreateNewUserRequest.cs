using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Auth.Requests;

public sealed record CreateNewUserRequest(
  string Username,
  string Name,
  string Email,
  int DepartmentId,
  string Role,
  int LevelId,
  int PositionId) : IRequest<ActionResponse>;