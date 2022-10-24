﻿using Core.Entities.Bookings;
using Core.Entities.Candidates;
using SharedKernel.Bases;
using SharedKernel.Enums;

namespace Core.Entities.Recruitments;

public class Application : ModifyEntity
{
  private Application() { }

  public Application(int candidateId, string attachment)
  {
    CandidateId = candidateId;
    Attachment = attachment;
    Status = SharedKernel.Enums.Status.WaitBookingInterview;
  }

  public Application(Candidate candidate, string attachment)
  {
    Candidate = candidate;
    Attachment = attachment;
    Status = SharedKernel.Enums.Status.WaitBookingInterview;
  }

  public int CandidateId { get; private set; }
  public int RecruitmentId { get; private set; }

  public string Attachment { get; private set; } = string.Empty;

  public virtual Candidate? Candidate { get; private set; }
  public virtual Recruitment? Recruitment { get; private set; }
  public virtual Booking? Booking { get; private set; }

  public void UpdateAttachment(string attachment) => Attachment = attachment;

  public void UpdateStatus(Status status) => Status = status;

  public Booking BookingInterview(Booking booking)
  {
    Booking = booking;
    Status = SharedKernel.Enums.Status.BookedInterview;
    return Booking;
  }
  public void BookingInterview(Booking booking, int id)
  {
    Booking = booking;
    Booking.Id = id;
    Status = SharedKernel.Enums.Status.BookedInterview;
  }
}