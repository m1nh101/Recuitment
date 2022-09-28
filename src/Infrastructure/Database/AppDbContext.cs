using Core.Entities;
using Core.Interfaces;
using Infrastructure.Database.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Bases;

namespace Infrastructure.Database;

public class AppDbContext : IdentityDbContext<User>, IAppDbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
    builder.ApplyConfiguration(new PositionEntityConfiguration());
		builder.ApplyConfiguration(new SkillTagEntityConfiguration());
		builder.ApplyConfiguration(new LevelEntityConfiguration());
		builder.ApplyConfiguration(new DepartmentEntityConfiguration());
		builder.ApplyConfiguration(new RecruitmentEntityConfiguration());
		builder.ApplyConfiguration(new CandidateEntityConfiguration());
		builder.ApplyConfiguration(new CandidateSkillTagEntityConfiguration());
		builder.ApplyConfiguration(new BookingEntityConfiguration());
		builder.ApplyConfiguration(new InterviewEntityConfiguration());
		builder.ApplyConfiguration(new InterviewResultEntityConfiguration());

    builder.Entity<User>(config =>
    {
      config.HasOne(e => e.Department)
        .WithMany(e => e.Users)
        .HasForeignKey(e => e.DepartmentId);
    });

    base.OnModelCreating(builder);
	}

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		foreach(var entry in ChangeTracker.Entries<ModifyEntity>())
		{
			if(entry.State == EntityState.Added)
			{
				entry.Entity.CreatedDate = DateTime.Now;
				entry.Entity.ModifiedDate = DateTime.Now;
			}

			if(entry.State == EntityState.Modified)
			{
				entry.Entity.ModifiedDate = DateTime.Now;
			}
		}

		return base.SaveChangesAsync(cancellationToken);
	}

	public Task<int> Commit() => SaveChangesAsync();

	public DbSet<Level> Levels => Set<Level>();
	public DbSet<Department> Departments => Set<Department>();
	public DbSet<Booking> Bookings => Set<Booking>();
	public DbSet<SkillTag> SkillTags => Set<SkillTag>();
	public DbSet<Position> Positions => Set<Position>();
}