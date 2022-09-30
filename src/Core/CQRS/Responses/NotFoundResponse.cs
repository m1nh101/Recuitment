using System.Net;

namespace Core.CQRS.Responses;

public sealed class NotFoundResponse : ActionResponse
{
  private readonly HttpStatusCode _status = HttpStatusCode.NotFound;
  private readonly string _message = "Không tìm thấy tài nguyên";

  public override HttpStatusCode StatusCode => _status;
  public override string Message => _message;
}