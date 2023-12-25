﻿using FinControl.Business.Models.AuditableEntities;

namespace FinControl.Business.Models;

public class Category : RemovableEntity
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public List<Transaction> Transactions { get; set; }
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
}