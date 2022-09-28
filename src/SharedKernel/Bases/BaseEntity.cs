using SharedKernel.Enums;

namespace SharedKernel.Bases;

public abstract class BaseEntity
{
  public int Id { get; set; }
  public Status Status { get; set; }
}