using AutoMapper;
using Core.CQRS.Responses;
using Core.Entities.Recruitments;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Recruitments.Create;

public sealed class CreateRecruitmentRequestHandler
  : IRequestHandler<CreateRecruitmentRequest, ActionResponse>
{
    private readonly IAppDbContext _context;

    private readonly IMapper _mapper;
    public CreateRecruitmentRequestHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ActionResponse> Handle(CreateRecruitmentRequest request, CancellationToken cancellationToken)
    {
      var recruitment = new Recruitment(request.Name, request.Content, request.Benifit, 
          request.StartDate, request.EndDate, request.SalaryMin, request.SalaryMax, 
          request.ExperienceFrom, request.ExperienceTo, request.Number, 
          request.PositionId, request.DepartmentId);

      await _context.Recruitments.AddAsync(recruitment, cancellationToken);
      await _context.Commit();

      var response = _mapper.Map<CreatedRecruitmentResponse>(recruitment);

      return new SuccessResponse("Tạo mới thành công", response);
    }
}
