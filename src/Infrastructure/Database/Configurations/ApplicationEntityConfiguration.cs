using Core.Entities.Recruitments;
using Infrastructure.Database.Configurations.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class ApplicationEntityConfiguration : ModifyEntityConfiguration<Application>
{
  public override void Configure(EntityTypeBuilder<Application> builder)
  {
    builder.ToTable("Applications");

    builder.HasOne(e => e.Candidate)
      .WithMany(e => e.Applications)
      .HasForeignKey(e => e.CandidateId);

    builder.HasOne(e => e.Recruitment)
      .WithMany(e => e.Applications)
      .HasForeignKey(e => e.RecruitmentId);

    base.Configure(builder);
  }
}