using Core.Entities.Candidates;
using Infrastructure.Database.Configurations.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Commons;

namespace Infrastructure.Database.Configurations;

public class CandidateEntityConfiguration : ModifyEntityConfiguration<Candidate>
{
  public override void Configure(EntityTypeBuilder<Candidate> builder)
  {
    builder.ToTable("Candidates");

    builder.Property(e => e.Name)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(500)
      .IsRequired();

    builder.Property(e => e.Email)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(500)
      .IsRequired();

    builder.Property(e => e.Phone)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(500)
      .IsRequired();

    builder.Property(e => e.Qualification)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(500)
      .IsRequired();

    base.Configure(builder);
  }
}