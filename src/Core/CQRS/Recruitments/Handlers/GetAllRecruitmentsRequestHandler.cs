using AutoMapper;
using Core.CQRS.Recruitments.Requests;
using Core.CQRS.Recruitments.Responses;
using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Recruitments.Handlers;

public class GetAllRecruitmentsRequestHandler : IRequestHandler<GetAllRecruitmentsRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public GetAllRecruitmentsRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public Task<ActionResponse> Handle(GetAllRecruitmentsRequest request, CancellationToken cancellationToken)
  {
    var query = _context.Recruitments.
      Select(item => ListRecruitmentResponse.ConvertFrom(item))
      .AsNoTracking();

    var response = new SuccessResponse("Thành công", query);

    return Task.FromResult<ActionResponse>(response);
  }
}