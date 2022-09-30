using System.Net;

namespace Core.CQRS.Responses;

public abstract class ActionResponse
{
  public abstract HttpStatusCode StatusCode { get; }
  public abstract string Message { get; }
  public virtual object? Data { get; set; }
  public virtual object? Errors { get; set; }
}