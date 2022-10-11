using Core.CQRS.Bookings.Requests;
using Core.CQRS.Bookings.Respones;
using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Bookings.Handlers;

public sealed class GetAllBookingRequesHandler : IRequestHandler<GetAllBookingRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public GetAllBookingRequesHandler(IAppDbContext context)
  {
    _context = context;
  }
  
  public Task<ActionResponse> Handle(GetAllBookingRequest request, CancellationToken cancellationToken)
  {
    var query = _context.Applications
      .Include(e => e.Booking)
      .ThenInclude(d => d!.Interview)
      .Include(e => e.Recruitment)
      .Include(e => e.Candidate)
      .Select(e => new ListBookingResponse
      {
        Id = e.Id,
        CandidateName = e.Candidate!.Name,
        RecruitmentTitle = e.Recruitment!.Name,
        Start = e.Booking!.Interview!.StartTime,
        End = e.Booking!.Interview!.EndTime
      })
      .AsNoTracking();

    var response = new SuccessResponse("Thành công", query);

    return Task.FromResult<ActionResponse>(response);
  }
}