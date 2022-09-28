using Core.Entities;
using Infrastructure.Database.Configurations.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Commons;

namespace Infrastructure.Database.Configurations;

public class DepartmentEntityConfiguration : BaseEntityConfiguration<Department>
{
  public override void Configure(EntityTypeBuilder<Department> builder)
  {
    builder.ToTable("Departments");

    builder.Property(e => e.Name)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(500);

    builder.Property(e => e.Location)
      .HasColumnType(SQLColumnType.NVARCHAR)
      .HasMaxLength(500);

    base.Configure(builder);
  }
}