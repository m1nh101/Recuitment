﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Bases;

namespace Infrastructure.Database.Configurations.Commons;

public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
  where TEntity : BaseEntity
{
  public virtual void Configure(EntityTypeBuilder<TEntity> builder)
  {
    builder.HasKey(e => e.Id);
    builder.Property(e => e.Id).ValueGeneratedOnAdd();
  }
}