using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Interviews.Requests;

public sealed record GetInterviewByRecruitmentRequest(
  int RecruitmentId
) : IRequest<ActionResponse>;