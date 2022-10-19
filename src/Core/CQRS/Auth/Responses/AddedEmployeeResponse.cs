namespace Core.CQRS.Auth.Responses;

public class AddedEmployeeResponse
{
  public string Name { get; set; } = string.Empty;
  public string Id { get; set; } = string.Empty;
  public int DepartmentId { get; set; }
  public string Role { get; set; } = string.Empty;
  public int LevelId { get; set; }
  public int PositionId { get; set; }
}