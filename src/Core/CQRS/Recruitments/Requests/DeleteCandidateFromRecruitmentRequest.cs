using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Recruitments.Requests;

public sealed record DeleteCandidateFromRecruitmentRequest(
  int RecruitmentId,
  int CandidateId) : IRequest<ActionResponse>;