using SharedKernel.Bases;

namespace Core.Entities;

public class Level : BaseEntity
{
  public string Name { get; set; } = string.Empty;

  public virtual ICollection<InterviewResult>? Interviews { get; set; }
}

