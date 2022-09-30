namespace Core.CQRS.Candidates.Responses;

public class ListCandidateResponse
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;
  public string Attachment { get; set; } = string.Empty;
}