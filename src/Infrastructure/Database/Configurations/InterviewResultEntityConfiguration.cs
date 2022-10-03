using Core.Entities;
using Infrastructure.Database.Configurations.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Commons;

namespace Infrastructure.Database.Configurations;

public class InterviewResultEntityConfiguration : ModifyEntityConfiguration<InterviewResult>
{
  public override void Configure(EntityTypeBuilder<InterviewResult> builder)
  {
    builder.ToTable("InterviewResults");

    builder.Property(e => e.Note)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(1000)
      .IsRequired();

    builder.Property(e => e.Experience)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(1000)
      .IsRequired();

    builder.Property(e => e.Skill)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(1000)
      .IsRequired();

    builder.Property(e => e.ResolveProblem)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(1000)
      .IsRequired();

    builder.Property(e => e.Attitude)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(1000)
      .IsRequired();

    builder.Property(e => e.SelfLearning)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(1000)
      .IsRequired();

    builder.Property(e => e.Desire)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(1000)
      .IsRequired();

    builder.Property(e => e.SalaryFrom)
      .HasColumnType(SQLColumnType.INT);

    builder.Property(e => e.SalaryTo)
      .HasColumnType(SQLColumnType.INT);

    builder.HasOne(e => e.Level)
      .WithMany(e => e.Interviews)
      .HasForeignKey(e => e.LevelId);

    builder.HasOne(e => e.Interview)
      .WithOne(e => e.Result)
      .HasForeignKey<InterviewResult>(e => e.InterviewId)
      .OnDelete(DeleteBehavior.NoAction);

    base.Configure(builder);
  }
}