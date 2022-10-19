using Core.Entities.Candidates;

namespace Core.Entities.Recruitments;

public partial class Recruitment
{
  private readonly List<Application> _applications = new();
  public IReadOnlyCollection<Application> Applications => _applications.AsReadOnly();

  public void Update(Recruitment request)
  {
    Name = request.Name;
    Benifit = request.Benifit;
    Content = request.Content;
    StartDate = request.StartDate;
    EndDate = request.EndDate;
    ExperienceFrom = request.ExperienceFrom;
    ExperienceTo = request.ExperienceTo;
    SalaryMax = request.SalaryMax;
    SalaryMin = request.SalaryMin;
    DepartmentId = request.DepartmentId;
    PositionId = request.PositionId;
  }

  public void CreateNewApplication(Candidate candidate, string attachment)
  {
    var application = new Application(candidate, attachment);
    _applications.Add(application);
  }

  public void CreateApplicationFromExistCandidateBefore(int candidateId, string attachment)
  {
    var isValidCandidate = _applications.Any(e => e.CandidateId == candidateId);

    if (!isValidCandidate)
      return;

    var application = new Application(candidateId, attachment);
    _applications.Add(application);
  }

  public void RemoveApplication(int id)
  {
    var application = _applications.FirstOrDefault(e => e.Id == id);

    if (application != null)
      _applications.Remove(application);
  }

  public void UpdateApplication(Candidate source, string attachment)
  {
    var application = _applications.FirstOrDefault(e => e.CandidateId == source.Id);

    if (application == null)
      throw new NullReferenceException();

    application.UpdateAttachment(attachment);
    application.Candidate!.Update(source);
  }
}