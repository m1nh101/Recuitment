using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Interfaces;

public interface IAppDbContext
{
  DbSet<Booking> Bookings { get; }
  DbSet<Department> Departments { get; }
  DbSet<Level> Levels { get; }
  DbSet<Position> Positions { get; }
  DbSet<SkillTag> SkillTags { get; }
  Task<int> Commit();
}