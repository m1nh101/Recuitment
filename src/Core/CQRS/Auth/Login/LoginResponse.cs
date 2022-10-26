namespace Core.CQRS.Auth.Login;

public sealed record LoginResponse(
  string Email,
  string Name,
  string Token,
  string StaffId
);