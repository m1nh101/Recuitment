using AutoMapper;
using Core.CQRS.Interviews.Requests;
using Core.CQRS.Interviews.Responses;
using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Interviews.Handlers;

public sealed class GetInterviewByRecruitmentRequestHandler
  : IRequestHandler<GetInterviewByRecruitmentRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly IMapper _mapper;

  public GetInterviewByRecruitmentRequestHandler(IAppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public Task<ActionResponse> Handle(GetInterviewByRecruitmentRequest request, CancellationToken cancellationToken)
  {
    var applications = _context.Applications
      .Include(e => e.Candidate)
      .Include(e => e.Booking!)
      .ThenInclude(e => e.Interview)
      .Where(e => e.RecruitmentId == request.RecruitmentId)
      .Select(e => new ListInterview(e.Id, e.Candidate!.Name, e.Booking!.Date, e.Booking!.Interview!.StartTime, e.Booking!.Interview!.EndTime, e.Booking!.Status))
      .AsNoTracking();

    var response = new SuccessResponse("Thành công", applications);

    return Task.FromResult<ActionResponse>(response);
  }
}