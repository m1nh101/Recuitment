using Core.CQRS.Responses;
using MediatR;
using SharedKernel.Enums;

namespace Core.CQRS.Candidate.Add;

public sealed record AddCandidateRequest(
  string Name,
  string Email,
  string Phone,
  DateTime Birthday,
  string Address,
  Gender Gender,
  string Qualification,
  int RecruitmentId,
  int Id,
  string Attachment
) : IRequest<ActionResponse>;
