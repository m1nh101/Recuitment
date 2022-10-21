using Core.CQRS.Responses;
using MediatR;
using SharedKernel.Enums;

namespace Core.CQRS.Applications.Apply;

public sealed record ApplyToRecruitmentRequest(
  int Id,
  string Name,
  string Phone,
  string Email,
  Gender Gender,
  string Address,
  DateTime Birthday,
  string Qualification,
  string? Note,
  string Attachment
) : IRequest<ActionResponse>;