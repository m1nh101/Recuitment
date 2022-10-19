using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Recruitments.Requests;

public sealed record UpdateRecruitmentRequest(
  int Id,
  CreateNewRecruitmentRequest Payload) : IRequest<ActionResponse>;