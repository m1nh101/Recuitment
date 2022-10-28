using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Applications.Detail;

public sealed class GetApplicationDetailRequestHandler
  : IRequestHandler<GetApplicationDetailRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public GetApplicationDetailRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(GetApplicationDetailRequest request, CancellationToken cancellationToken)
  {
    InterviewData? interview = null;
    InterviewResultResponse? result = null;

    var application = await _context.Applications
      .Include(e => e.Candidate)
      .Include(e => e.Booking!)
      .ThenInclude(e => e.Interview!)
      .ThenInclude(e => e.Result)
      .AsNoTracking()
      .FirstOrDefaultAsync(e => e.Id == request.ApplicationId, cancellationToken);

    if(application == null)
      throw new NullReferenceException();

    var candidate = application.Candidate!;

    if (application.Status == SharedKernel.Enums.Status.BookedInterview)
    {
      var interviewHolder = application.Booking!;
      interview = new InterviewData(interviewHolder.Date, interviewHolder.Interview!.StartTime, interviewHolder.Interview!.EndTime,
        interviewHolder.Status, interviewHolder.ReviewerId);

      if(interviewHolder.Interview.Result != null)
      {
        var interviewResult = interviewHolder.Interview!.Result;

        result = new InterviewResultResponse(interviewResult.Attitude, interviewResult.SelfLearning, interviewResult.Skill,
          interviewResult.ResolveProblem, interviewResult.Desire, interviewResult.Experience, interviewResult.SalaryFrom,
          interviewResult.SalaryTo, interviewResult.Note, interviewResult.LevelId);
      }
    }

    var candidateData = new CandidateData(candidate.Name, candidate.Birthday, candidate.Gender,
      candidate.Address, candidate.Email, application.Attachment, candidate.Qualification);

    var response = new GetApplicationDetailResponse(candidateData, interview, result, application.Status);

    return new SuccessResponse("Thành công", response);
  }
}