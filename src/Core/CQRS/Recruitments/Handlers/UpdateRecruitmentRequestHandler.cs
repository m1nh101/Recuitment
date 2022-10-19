using AutoMapper;
using Core.CQRS.Recruitments.Requests;
using Core.CQRS.Recruitments.Responses;
using Core.CQRS.Responses;
using Core.Entities.Recruitments;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Recruitments.Handlers;

public class UpdateRecruitmentRequestHandler
  : IRequestHandler<UpdateRecruitmentRequest, ActionResponse>
{
  private readonly IMapper _mapper;
  private readonly IAppDbContext _context;

  public UpdateRecruitmentRequestHandler(IMapper mapper, IAppDbContext context)
  {
    _mapper = mapper;
    _context = context;
  }

  public async Task<ActionResponse> Handle(UpdateRecruitmentRequest request, CancellationToken cancellationToken)
  {
    var recruitment = await _context.Recruitments.FindAsync(request.Id);

    if (recruitment == null)
      return new NotFoundResponse();

    var payload = _mapper.Map<Recruitment>(request);

    recruitment.Update(payload);

    _context.Recruitments.Update(recruitment);
    await _context.Commit();

    var response = _mapper.Map<GeneralRecruitmentResponse>(recruitment);

    return new SuccessResponse("Thành công", response);
  }
}