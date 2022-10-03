using Core.Entities.Bookings;
using Infrastructure.Database.Configurations.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Commons;

namespace Infrastructure.Database.Configurations;

public class BookingEntityConfiguration : ModifyEntityConfiguration<Booking>
{
  public override void Configure(EntityTypeBuilder<Booking> builder)
  {
    builder.ToTable("Bookings");

    builder.Property(e => e.Name)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(500)
      .IsRequired();

    builder.Property(e => e.Note)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(500);

    builder.Property(e => e.Place)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(500);

    builder.Property(e => e.MeetingUrl)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(500);

    builder.Property(e => e.ReviewerId)
      .IsRequired();

    builder.HasOne(e => e.Application)
      .WithOne(e => e.Booking)
      .HasForeignKey<Booking>(e => e.ApplicationId);

    base.Configure(builder);
  }
}