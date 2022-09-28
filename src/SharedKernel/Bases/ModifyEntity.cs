namespace SharedKernel.Bases;

public abstract class ModifyEntity : BaseEntity
{
  public string CreatedBy { get; set; } = string.Empty;
  public DateTime CreatedDate { get; set; }
  public string ModifiedBy { get; set; } = string.Empty;
  public DateTime ModifiedDate { get; set; }
}