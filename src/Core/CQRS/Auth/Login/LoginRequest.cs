using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Auth.Login;

public sealed record LoginRequest(
  string Email,
  string Password
) : IRequest<ActionResponse>;