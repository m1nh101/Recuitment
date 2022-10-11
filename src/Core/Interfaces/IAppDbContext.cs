using Core.Entities;
using Core.Entities.Bookings;
using Core.Entities.Candidates;
using Core.Entities.Recruitments;
using Microsoft.EntityFrameworkCore;

namespace Core.Interfaces;

public interface IAppDbContext
{
  DbSet<Recruitment> Recruitments { get; }
  DbSet<Application> Applications { get; }
  DbSet<Booking> Bookings { get; }
  DbSet<Department> Departments { get; }
  DbSet<Level> Levels { get; }
  DbSet<Position> Positions { get; }
  DbSet<SkillTag> SkillTags { get; }
  DbSet<Candidate> Candidates { get; }
  Task<int> Commit();
}