using SharedKernel.Enums;

namespace Core.CQRS.Candidates.Responses;

public class CandidateDetailResponse : ListCandidateResponse
{
  public Gender Gender { get; set; }
  public DateTime Birthday { get; set; }
  public string Note { get; set; } = string.Empty;
  public string Address { get; set; } = string.Empty;
  public string Qualification { get; set; } = string.Empty;
}