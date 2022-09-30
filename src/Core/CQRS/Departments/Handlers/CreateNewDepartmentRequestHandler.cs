using AutoMapper;
using Core.CQRS.Departments.Requests;
using Core.CQRS.Departments.Responses;
using Core.CQRS.Responses;
using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Departments.Handlers;

public class CreateNewDepartmentRequestHandler : IRequestHandler<CreateNewDepartmentRequest, ActionResponse>
{
  private readonly IMapper _mapper;
  private readonly IAppDbContext _context;

  public CreateNewDepartmentRequestHandler(IAppDbContext context,
    IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<ActionResponse> Handle(CreateNewDepartmentRequest request, CancellationToken cancellationToken)
  {
    var department = _mapper.Map<Department>(request);

    await _context.Departments.AddAsync(department);
    await _context.Commit();

    var response = _mapper.Map<GeneralDepartmentResponse>(department);

    return new SuccessResponse("Thêm thành công", response);
  }
}