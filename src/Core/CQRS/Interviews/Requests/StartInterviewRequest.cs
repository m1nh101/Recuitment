using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Interviews.Requests;

public sealed record StartInterviewRequest(
  int ApplicationId
) : IRequest<ActionResponse>;