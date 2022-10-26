using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Helpers;

public sealed record ListLevel(
  int Id,
  string Name
);

public  sealed record ListDepartment(
  int Id,
  string Name,
  string Location
);

public sealed record ListPosition(
  int Id,
  string Name
);

public class Util
{
  private readonly IAppDbContext _context;

  public Util(IAppDbContext context)
  {
    _context = context;
  }

  public Task<IQueryable<ListDepartment>> GetDepartments()
  {
    var response = _context.Departments.AsNoTracking()
      .Select(e => new ListDepartment(e.Id, e.Name, e.Location));

    return Task.FromResult(response);
  }

  public Task<IQueryable<ListLevel>> GetLevels()
  {
    var response = _context.Levels.AsNoTracking()
      .Select(e => new ListLevel(e.Id, e.Name));

    return Task.FromResult(response);
  }

  public Task<IQueryable<ListPosition>> GetPositions()
  {
    var response = _context.Positions.AsNoTracking()
      .Select(e => new ListPosition(e.Id, e.Name));

    return Task.FromResult(response);
  }
}