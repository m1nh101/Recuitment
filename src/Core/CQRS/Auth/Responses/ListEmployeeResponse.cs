namespace Core.CQRS.Auth.Responses;

public class ListEmployeeResponse
{
  public string Name { get; set; } = string.Empty;
  public string Id { get; set; } = string.Empty;
  public string Department { get; set; } = string.Empty;
  public string Role { get; set; } = string.Empty;
  public string Level { get; set; } = string.Empty;
  public string Position { get; set; } = string.Empty;
}