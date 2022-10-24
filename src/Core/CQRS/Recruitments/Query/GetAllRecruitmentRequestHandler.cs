using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Recruitments.Query;

public sealed class GetAllRecruitmentRequestHandler
  : IRequestHandler<GetAllRecruitmentRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

    public GetAllRecruitmentRequestHandler(IAppDbContext context)
    {
        _context = context;
    }

    public Task<ActionResponse> Handle(GetAllRecruitmentRequest request, CancellationToken cancellationToken)
    {
      var query = _context.Recruitments
        .AsNoTracking()
        .Select(e => new AllRecruitmentResponse(
          e.Id, e.Name, e.StartDate, e.EndDate,
          e.SalaryMin, e.SalaryMax, e.ExperienceFrom, e.ExperienceTo,
          e.Number, e.Status
        ));

        var response = new SuccessResponse("Thành công", query);

        return Task.FromResult<ActionResponse>(response);
    }
}