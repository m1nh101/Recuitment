using Core.Entities;
using Infrastructure.Database.Configurations.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Commons;

namespace Infrastructure.Database.Configurations;

public class LevelEntityConfiguration : BaseEntityConfiguration<Level>
{
  public override void Configure(EntityTypeBuilder<Level> builder)
  {
    builder.ToTable("Levels");

    builder.Property(e => e.Name)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(500)
      .IsRequired();
    
    base.Configure(builder);
  }
}