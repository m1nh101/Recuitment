using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Candidates.Requests;

public sealed record UpdateCandidateRequest(
  int Id,
  AddCandidateToRecruitmentRequest Payload) : IRequest<ActionResponse>;