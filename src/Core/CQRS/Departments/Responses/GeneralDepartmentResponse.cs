namespace Core.CQRS.Departments.Responses;

public class GeneralDepartmentResponse
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string Location { get; set; } = string.Empty;
}