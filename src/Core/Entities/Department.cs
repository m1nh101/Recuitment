using SharedKernel.Bases;

namespace Core.Entities;

public class Department : BaseEntity
{
  public string Name { get; set; } = string.Empty;

  public string Location { get; set; } = string.Empty;

  public virtual ICollection<User>? Users { get; set; }
  public virtual ICollection<Recruitment>? Recruitments { get; set; }
}