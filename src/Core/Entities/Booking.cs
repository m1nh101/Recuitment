﻿using SharedKernel.Bases;
using SharedKernel.Enums;

namespace Core.Entities;

public class Booking : ModifyEntity
{
  public string Name { get; set; } = string.Empty;
  public DateTime Date { get; set; }
  public string Note { get; set; } = string.Empty;
  public string Place { get; set; } = string.Empty;
  public string MeetingUrl { get; set; } = string.Empty;
  public MeetingType MeetingType { get; set; }
  public string ReviewerId { get; set; } = string.Empty;
  public int CandidateId { get; set; }

  public virtual Candidate? Candiate { get; set; }
  public virtual Interview? Interview { get; set; }
}

