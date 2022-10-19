using System.Net;

namespace Core.CQRS.Responses;

public class FailedValidationResponse : ActionResponse
{
  public FailedValidationResponse(object errors)
  {
    Errors = errors;
  }

  public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

  public override string Message => "Yêu cầu không khả dụng";
}