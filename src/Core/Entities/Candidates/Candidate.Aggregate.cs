using Core.CQRS.Candidates.Requests;
using Core.Entities.Recruitments;

namespace Core.Entities.Candidates;

public partial class Candidate
{
  private readonly List<Application> _applications = new();
  public IReadOnlyCollection<Application> Applications => _applications.AsReadOnly();

  public static Candidate Create(AddCandidateToRecruitmentRequest request)
  {
    return new Candidate
    {
      Name = request.Name,
      Birthday = request.Birthday,
      Phone = request.Phone,
      Email = request.Email,
      Note = request.Note,
      Address = request.Address,
      Gender = request.Gender,
      Qualification = request.Qualification,
    };
  }

  public void Update(Candidate source)
  {
    Name = source.Name;
    Email = source.Email;
    Phone = source.Phone;
    Gender = source.Gender;
    Address = source.Address;
    Note = source.Note;
    Birthday = source.Birthday;
    Qualification = source.Qualification;
  }

  public void Update(Candidate source, int recruitmentId, string attachment)
  {
    var recruitment = _applications.FirstOrDefault(e => e.RecruitmentId == recruitmentId);

    if (recruitment == null)
      throw new NullReferenceException();

    Update(source);
    recruitment.UpdateAttachment(attachment);
  }

  public string GetAttachmentByRecruitment(int recruitmentId)
  {
    var application = _applications.FirstOrDefault(e => e.RecruitmentId == recruitmentId);

    if (application == null)
      throw new NullReferenceException();

    return application.Attachment;
  }
}