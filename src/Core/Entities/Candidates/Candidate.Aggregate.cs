using Core.Entities.Recruitments;
using SharedKernel.Enums;

namespace Core.Entities.Candidates;

public partial class Candidate
{
  private readonly List<Application> _applications = new();
  public IReadOnlyCollection<Application> Applications => _applications.AsReadOnly();

  public static Candidate Create(string name, string email, string phone, DateTime birthday,
    string address, string qualification, Gender gender, string? note)
  {
    return new Candidate
    {
      Name = name,
      Birthday = birthday,
      Phone = phone,
      Email = email,
      Note = note ?? string.Empty,
      Address = address,
      Gender = gender,
      Qualification = qualification,
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