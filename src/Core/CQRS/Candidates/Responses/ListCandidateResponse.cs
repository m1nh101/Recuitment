using SharedKernel.Enums;

namespace Core.CQRS.Candidates.Responses;

public class ListCandidateResponse
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;
  public Gender Gender { get; set; }
  public string Address { get; set; } = string.Empty;
  public DateTime Birthday { get; set; }
  public Status Status { get; set; }
}