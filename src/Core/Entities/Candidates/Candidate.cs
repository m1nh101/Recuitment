using Core.CQRS.Candidates.Requests;
using SharedKernel.Bases;
using SharedKernel.Enums;

namespace Core.Entities.Candidates;

public partial class Candidate : ModifyEntity
{
  public string Name { get; private set; } = string.Empty;
  public string Email { get; private set; } = string.Empty;
  public string Phone { get; private set; } = string.Empty;
  public string Qualification { get; private set; } = string.Empty;
  public Gender Gender { get; private set; }
  public DateTime Birthday { get; private set; }
  public string Note { get; private set; } = string.Empty;
  public string Address { get; private set; } = string.Empty;

  public virtual ICollection<CandidateSkillTag>? SkillTags { get; set; }
}