using Core.CQRS.Responses;
using MediatR;
using SharedKernel.Enums;

namespace Core.CQRS.Candidates.Requests;

public class AddCandidateToRecruitmentRequest : IRequest<ActionResponse>
{
  public string Name { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;
  public string Address { get; set; } = string.Empty;
  public string Attachment { get; set; } = string.Empty; //cv attach
  public string Qualification { get; set; } = string.Empty;
  public Gender Gender { get; set; }
  public DateTime Birthday { get; set; }
  public string Note { get; set; } = string.Empty;
  public int RecruitmentId { get; set; }
}