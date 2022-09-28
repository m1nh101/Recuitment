using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Bases;

namespace Infrastructure.Database.Configurations.Commons;

public abstract class ModifyEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity>,
  IEntityTypeConfiguration<TEntity>
  where TEntity : ModifyEntity
{
  public override void Configure(EntityTypeBuilder<TEntity> builder)
  {
    builder.Property(e => e.CreatedBy).IsRequired();
    builder.Property(e => e.ModifiedBy).IsRequired();

    base.Configure(builder);
  }
}