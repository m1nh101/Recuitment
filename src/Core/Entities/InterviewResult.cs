using SharedKernel.Bases;

namespace Core.Entities;

public class InterviewResult : ModifyEntity
{
  public string Note { get; set; } = string.Empty;
  public string Experience { get; set; } = string.Empty;
  public string Skill { get; set; } = string.Empty;
  public string ResolveProblem { get; set; } = string.Empty;
  public string Attitude { get; set; } = string.Empty;
  public string SelfLearning { get; set; } = string.Empty;
  public string Desire { get; set; } = string.Empty;
  public int SalaryFrom { get; set; }
  public int SalaryTo { get; set; }
  public int LevelId { get; set; }
  public int InterviewId { get; set; }

  public virtual Interview? Interview { get; set; }
  public virtual Level? Level { get; set; }

  public void Update(InterviewResult result)
  {
    Note = result.Note;
    Experience = result.Experience;
    Skill = result.Skill;
    Attitude = result.Attitude;
    SelfLearning = result.SelfLearning;
    ResolveProblem = result.ResolveProblem;
    Desire = result.SelfLearning;
    SalaryFrom = result.SalaryFrom;
    SalaryTo = result.SalaryTo;
    LevelId = result.LevelId;
  }
}