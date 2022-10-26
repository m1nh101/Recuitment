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

  public Task<ActionResponse> Handle(GetRecruitmentDetailRequest request, CancellationToken cancellationToken)
  {
    var recruitments = _context.Recruitments
      .Include(e => e.Applications)
      .ThenInclude(e => e.Candidate)
      .Select(e => new RecruitmentDetailResponse(
        e.Id, e.Name, e.Content, e.Benifit,
        e.SalaryMin, e.SalaryMax, e.ExperienceFrom, e.ExperienceTo,
        e.Number, e.StartDate, e.EndDate, e.PositionId, e.DepartmentId, e.Applications
          .Select(d => new ApplicationAppliedInRecruitment(
            d.Id, d.Candidate!.Name, d.Candidate!.Gender, d.Candidate!.Email,
            d.Candidate!.Phone, d.Candidate!.Address, d.Status
          ))
      ))
        .AsNoTracking()
        .AsEnumerable();

    var recruitment = recruitments.FirstOrDefault(e => e.Id == request.Id);

    ActionResponse response = recruitment == null ? new NotFoundResponse()
      : new SuccessResponse("Thành công", recruitment);

    return Task.FromResult(response);
  }
}