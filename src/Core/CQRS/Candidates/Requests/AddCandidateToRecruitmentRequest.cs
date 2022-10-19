using Core.CQRS.Responses;
using MediatR;
using SharedKernel.Enums;

namespace Core.CQRS.Candidates.Requests;

public sealed record AddCandidateToRecruitmentRequest(
  int Id,
  string Name,
  string Email,
  string Phone,
  string Password,
  string Address,
  string Attachment,
  string Qualification,
  Gender Gender,
  DateTime Birthday,
  string Note,
  int RecruitmentId) : IRequest<ActionResponse>;