using Core.CQRS.Interviews.Requests;
using Core.CQRS.Interviews.Responses;
using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Interviews.Handlers;

public class GetInterviewByReviewerRequestHandler
  : IRequestHandler<GetInterviewByReviewerRequest, ActionResponse>
{
  private readonly ICurrentUser _user;
  private readonly IAppDbContext _context;

  public GetInterviewByReviewerRequestHandler(ICurrentUser user, IAppDbContext context)
  {
    _user = user;
    _context = context;
  }

  public Task<ActionResponse> Handle(GetInterviewByReviewerRequest request, CancellationToken cancellationToken)
  {
    if (_user.Id == string.Empty)
      throw new NullReferenceException();

    var applications = _context.Applications
      .Include(e => e.Candidate)
      .Include(e => e.Booking!)
      .ThenInclude(e => e.Interview)
      .Where(e => e.Booking!.ReviewerId == _user.Id)
      .Select(e => new ListInterview(e.Id, e.Candidate!.Name, e.Booking!.Date, e.Booking!.Interview!.StartTime, e.Booking!.Interview!.EndTime, e.Booking!.Status))
      .AsNoTracking();

    var response = new SuccessResponse("Thành công", applications);

    return Task.FromResult<ActionResponse>(response);
  }
}
