using Core.Entities;
using Infrastructure.Database.Configurations.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Commons;

namespace Infrastructure.Database.Configurations;

public class RecruitmentSkillTagEntityConfiguration : BaseEntityConfiguration<RecruitSkillTag>
{
  public override void Configure(EntityTypeBuilder<RecruitSkillTag> builder)
  {
    builder.ToTable("RecruitmentSkillTags");

    builder.Property(e => e.Number)
      .HasColumnType(SQLColumnType.DECIMAL)
      .HasPrecision(2);

    builder.HasOne(e => e.SkillTag)
      .WithMany(e => e.Recruiments)
      .HasForeignKey(e => e.SkillTagId);

    builder.HasOne(e => e.Recruitment)
      .WithMany(e => e.SkillTags)
      .HasForeignKey(e => e.RecruitmentId);

    base.Configure(builder);
  }
}