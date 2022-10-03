using AutoMapper;
using Core.CQRS.Recruitments.Requests;
using Core.CQRS.Recruitments.Responses;
using Core.CQRS.Responses;
using Core.Entities.Recruitments;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Recruitments.Handlers;

public class CreateRecruitmentRequestHandler : IRequestHandler<CreateNewRecruitmentRequest, ActionResponse>
{
  private readonly IMapper _mapper;
  private readonly IAppDbContext _context;

  public CreateRecruitmentRequestHandler(IAppDbContext context,
    IMapper mapper)
  {
    _mapper = mapper;
    _context = context;
  }

  public async Task<ActionResponse> Handle(CreateNewRecruitmentRequest request, CancellationToken cancellationToken)
  {
    var recruitment = Recruitment.Create(request);

    await _context.Recruitments.AddAsync(recruitment, cancellationToken);
    await _context.Commit();

    var response = _mapper.Map<GeneralRecruitmentResponse>(recruitment);

    return new SuccessResponse("Tạo mới thành công", response);
  }
}