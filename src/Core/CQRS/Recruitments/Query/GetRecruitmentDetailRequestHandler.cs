using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Recruitments.Query;

public sealed class GetRecruitmentDetailRequestHandler
  : IRequestHandler<GetRecruitmentDetailRequest, ActionResponse>
{
    private readonly IAppDbContext _context;

    public GetRecruitmentDetailRequestHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResponse> Handle(GetRecruitmentDetailRequest request, CancellationToken cancellationToken)
    {
      var recruitment = await _context.Recruitments
        .AsNoTracking()
        .Include(e => e.Applications)
        .ThenInclude(e => e.Candidate)
        .Select(e => new RecruitmentDetailResponse(
          e.Id, e.Name, e.Content, e.Benifit, 
          e.SalaryMin, e.SalaryMax, e.ExperienceFrom, e.ExperienceTo,
          e.Number, e.Applications
            .Select(d => new ApplicationAppliedInRecruitment(
              d.Id, d.Candidate!.Name, d.Candidate!.Gender, d.Candidate!.Email,
              d.Candidate!.Phone
            ))
        ))
        .FirstOrDefaultAsync(e => e.Id == request.Id);

      if(recruitment == null)
        return new NotFoundResponse();

      return new SuccessResponse("Thành công", recruitment);
    }
}