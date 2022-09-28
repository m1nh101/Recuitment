using Microsoft.AspNetCore.Identity;
using SharedKernel.Enums;

namespace Core.Entities;

public class User : IdentityUser
{
  public string Name { get; set; } = string.Empty;
  public DateTime JoinDate { get; set; }
  public DateTime LeaveDate { get; set; }
  public WorkType WorkType { get; set; }
  public Status Status { get; set; }

  public int DepartmentId { get; set; }
  public virtual Department? Department { get; set; }
}