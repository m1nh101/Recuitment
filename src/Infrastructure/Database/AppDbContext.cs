﻿using Core.Entities;
using Core.Entities.Bookings;
using Core.Entities.Candidates;
using Core.Entities.Recruitments;
using Core.Entities.Users;
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
		builder.ApplyConfiguration(new ApplicationEntityConfiguration());
		builder.ApplyConfiguration(new CandidateSkillTagEntityConfiguration());
		builder.ApplyConfiguration(new BookingEntityConfiguration());
		builder.ApplyConfiguration(new InterviewEntityConfiguration());
		builder.ApplyConfiguration(new InterviewResultEntityConfiguration());

    builder.Entity<User>(config =>
    {
      config.HasOne(e => e.Department)
        .WithMany(e => e.Users)
        .HasForeignKey(e => e.DepartmentId);

			config.HasOne(e => e.Level)
				.WithMany(e => e.Users)
				.HasForeignKey(e => e.LevelId);

			config.HasOne(e => e.Position)
				.WithMany(e => e.Users)
				.HasForeignKey(e => e.PositionId);
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

				//remove later
				entry.Entity.CreatedBy = "d1d99d84-f944-43c2-872a-8e66386ab936";
				entry.Entity.ModifiedBy = "d1d99d84-f944-43c2-872a-8e66386ab936";

      }

			if(entry.State == EntityState.Modified)
			{
				entry.Entity.ModifiedDate = DateTime.Now;
        entry.Entity.ModifiedBy = "d1d99d84-f944-43c2-872a-8e66386ab936"; // remove later
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
	public DbSet<Recruitment> Recruitments => Set<Recruitment>();
	public DbSet<Candidate> Candidates => Set<Candidate>();
	public DbSet<Application> Applications => Set<Application>();
}