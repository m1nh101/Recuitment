using SharedKernel.Enums;

namespace Core.CQRS.Applications.Detail;

public sealed record GetApplicationDetailResponse(
  CandidateData Candidate,
  BookingApplicationData? Booking,
  string Attachment,
  Status Status
);

public sealed record CandidateData(
  string Name,
  DateTime Birthday,
  Gender Gender,
  string Address,
  string Email
);

public sealed record BookingApplicationData(
  DateTime Date,
  string ReviewerId,
  Status Status
);

public sealed record InterviewData(
  DateTime Start,
  DateTime End,
  Status Status
);