﻿using Core.Entities.Recruitments;
using SharedKernel.Bases;

namespace Core.Entities;

public class Position : BaseEntity
{
  public string Name { get; set; } = string.Empty;

  public virtual ICollection<Recruitment>? Recruitments { get; set; }
}

