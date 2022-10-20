namespace Core.CQRS.Auth.Responses;

public record AuthenticationResponse(
  string Name,
  string Email);