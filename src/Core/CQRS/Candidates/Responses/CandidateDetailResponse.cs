namespace Core.CQRS.Candidates.Responses;

public class CandidateDetailResponse : ListCandidateResponse
{
  public string Note { get; set; } = string.Empty;
  public string Qualification { get; set; } = string.Empty;
  public string Attachment { get; set; } = string.Empty;
}