using AutoMapper;
using Core.CQRS.Candidates.Responses;
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
      .Include(e => e.Applications.Where(e => e.Status == SharedKernel.Enums.Status.Active))
      .ThenInclude(e => e.Candidate)
      .AsNoTracking()
      .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

    if (recruitment == null)
      return new NotFoundResponse();

    var responseData = _mapper.Map<RecruitmentDetailResponse>(recruitment);

    responseData.Candidates = recruitment.Applications.Select(e => new ListCandidateResponse
    {
      Name = e.Candidate!.Name,
      Id = e.CandidateId,
      Email = e.Candidate!.Email,
      Phone = e.Candidate!.Phone,
      Attachment = "",
      Address = e.Candidate!.Address,
      Gender = e.Candidate!.Gender,
      Birthday = e.Candidate!.Birthday
    }).ToArray();

    return new SuccessResponse("Thành công", responseData);
  }
}