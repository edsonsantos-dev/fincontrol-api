﻿using FinControl.Business.Models;

namespace FinControl.API.ViewModels;

public abstract class ViewModelBase<TEntity> where TEntity : Entity
{
    public Guid? Id { get; set; }
    public DateTime? AddedOn { get; set; }
    public Guid? AddedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public Guid? ModifiedBy { get; set; }

    public abstract TEntity ToModel();
}