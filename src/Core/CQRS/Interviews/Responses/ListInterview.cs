namespace Core.CQRS.Interviews.Responses;

public record ListInterview(
  int Id, //application id,
  string CandidateName,
  DateTime DateInterview,
  DateTime TimeStart,
  DateTime TimeEnd,
  SharedKernel.Enums.Status Status
);