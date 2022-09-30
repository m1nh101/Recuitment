using System.Net;

namespace Core.CQRS.Responses;

public sealed class SuccessResponse : ActionResponse
{
  private readonly HttpStatusCode _status = HttpStatusCode.OK;
  private readonly string _message;

  public SuccessResponse(string? message, object? data)
  {
    _message = message ?? "Thành công";
    Data = data;
  }

  public override HttpStatusCode StatusCode => _status;

  public override string Message => _message;
}