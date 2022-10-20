using System.Net;

namespace Core.CQRS.Responses;

public class BadRequestResponse : ActionResponse
{
  private readonly string _message;

  public BadRequestResponse(object errors, string? message)
  {
    Errors = errors;
    _message = message ?? "Failed";
  }

  public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

  public override string Message => _message;
}