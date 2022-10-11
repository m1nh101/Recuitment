using Microsoft.AspNetCore.Identity;
using SharedKernel.Enums;

namespace Core.Entities.Users;

public class User : IdentityUser
{
  public string Name { get;  set; } = string.Empty;
  public DateTime JoinDate { get; set; }
  public DateTime LeaveDate { get; set; }
  public WorkType WorkType { get; set; }
  public Status Status { get; set; }
  public string Role { get; set; } = string.Empty;

  public int DepartmentId { get; set; }
  public virtual Department? Department { get; set; }

  public int? PositionId { get; set; }
  public virtual Position? Position { get; set; }
  public int? LevelId { get; set; }
  public virtual Level? Level { get; set; }

  public static User Create(string username, string email, string name, string role)
  {
    return new User
    {
      Name = name,
      UserName = username,
      Email = email,
      JoinDate = DateTime.Now,
      WorkType = WorkType.FullTime,
      Role = role
    };
  }
}