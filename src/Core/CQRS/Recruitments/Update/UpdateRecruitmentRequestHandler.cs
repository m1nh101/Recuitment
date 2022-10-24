using AutoMapper;
using Core.CQRS.Responses;
using Core.Entities.Recruitments;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Recruitments.Update;

public sealed class UpdateRecruitmentRequestHandler
  : IRequestHandler<UpdateRecruitmentRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly IMapper _mapper;

    public UpdateRecruitmentRequestHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

    var response = _mapper.Map<UpdateRecruitmentResponse>(recruitment);

    return new SuccessResponse("Thành công", response);
    }
}
