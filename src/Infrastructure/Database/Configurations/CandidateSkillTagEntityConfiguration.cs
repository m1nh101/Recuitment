using Core.Entities;
using Infrastructure.Database.Configurations.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Commons;

namespace Infrastructure.Database.Configurations;

public class CandidateSkillTagEntityConfiguration : BaseEntityConfiguration<CandidateSkillTag>
{
  public override void Configure(EntityTypeBuilder<CandidateSkillTag> builder)
  {
    builder.ToTable("CandidateSkillTags");

    builder.Property(e => e.Number)
      .HasColumnType(SQLColumnType.DECIMAL)
      .HasPrecision(2);

    builder.HasOne(e => e.Candidate)
      .WithMany(e => e.SkillTags)
      .HasForeignKey(e => e.CandidateId);

    builder.HasOne(e => e.SkillTag)
      .WithMany(e => e.Candidates)
      .HasForeignKey(e => e.SkillTagId);

    base.Configure(builder);
  }
}