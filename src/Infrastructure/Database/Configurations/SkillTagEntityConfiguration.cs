using Core.Entities;
using Infrastructure.Database.Configurations.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Commons;

namespace Infrastructure.Database.Configurations;

public class SkillTagEntityConfiguration : BaseEntityConfiguration<SkillTag>
{
  public override void Configure(EntityTypeBuilder<SkillTag> builder)
  {
    builder.ToTable("SkillTags");

    builder.Property(e => e.Name)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(500)
      .IsRequired();

    base.Configure(builder);
  }
}