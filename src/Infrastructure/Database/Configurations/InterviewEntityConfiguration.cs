using Core.Entities;
using Infrastructure.Database.Configurations.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Commons;

namespace Infrastructure.Database.Configurations;

public class InterviewEntityConfiguration : ModifyEntityConfiguration<Interview>
{
  public override void Configure(EntityTypeBuilder<Interview> builder)
  {
    builder.ToTable("Interviews");

    builder.Property(e => e.Name)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(500)
      .IsRequired();

    builder.Property(e => e.Description)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(3000)
      .IsRequired();

    builder.HasOne(e => e.Booking)
      .WithOne(e => e.Interview)
      .HasForeignKey<Interview>(e => e.BookingId);

    base.Configure(builder);
  }
}