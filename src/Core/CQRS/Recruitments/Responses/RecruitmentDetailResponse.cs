using Core.CQRS.Candidates.Responses;

namespace Core.CQRS.Recruitments.Responses;

public class RecruitmentDetailResponse : ListRecruitmentResponse
{
  public string Content { get; set; } = string.Empty;
  public string Benifit { get; set; } = string.Empty;
  public int PositionId { get; set; }
  public int DepartmentId { get; set; }
  public ListCandidateResponse[] Candidates { get; set; } = Array.Empty<ListCandidateResponse>();
}