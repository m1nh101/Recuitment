using AutoMapper;
using Core.CQRS.Recruitments.Requests;
using Core.CQRS.Recruitments.Responses;
using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Recruitments.Handlers;

public class GetRecruitmentDetailRequestHandler : IRequestHandler<GetRecruitmentDetailRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly IMapper _mapper;

  public GetRecruitmentDetailRequestHandler(IAppDbContext context,
    IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<ActionResponse> Handle(GetRecruitmentDetailRequest request, CancellationToken cancellationToken)
  {
    var recruitment = await _context.Recruitments
      .Include(e => e.Candidates)
      .AsNoTracking()
      .FirstOrDefaultAsync(e => e.Id == request.Id);

    if (recruitment == null)
      return new NotFoundResponse();

    var responseData = _mapper.Map<RecruitmentDetailResponse>(recruitment);

    return new SuccessResponse("Thành công", responseData);
  }
}