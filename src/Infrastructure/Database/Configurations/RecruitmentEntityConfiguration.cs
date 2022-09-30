using Core.Entities;
using Infrastructure.Database.Configurations.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Commons;

namespace Infrastructure.Database.Configurations;

public class RecruitmentEntityConfiguration : ModifyEntityConfiguration<Recruitment>
{
  public override void Configure(EntityTypeBuilder<Recruitment> builder)
  {
    builder.ToTable("Recruiments");

    builder.Property(e => e.Name)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(500)
      .IsRequired();

    builder.Property(e => e.Content)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(1000)
      .IsRequired();

    builder.Property(e => e.Benifit)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(1000)
      .IsRequired();

    builder.Property(e => e.SalaryMin)
      .HasColumnType(SQLColumnType.INT);

    builder.Property(e => e.SalaryMax)
      .HasColumnType(SQLColumnType.INT);

    builder.Property(e => e.ExperienceFrom)
      .HasColumnType(SQLColumnType.TINYINT);

    builder.Property(e => e.Number)
      .HasColumnType(SQLColumnType.TINYINT);

    builder.HasOne(e => e.Position)
      .WithMany(e => e.Recruitments)
      .HasForeignKey(e => e.PositionId);

    builder.HasOne(e => e.Department)
      .WithMany(e => e.Recruitments)
      .HasForeignKey(e => e.DepartmentId);

    base.Configure(builder);
  }
}