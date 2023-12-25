﻿using FinControl.Business.Models;
using FinControl.Shared.Enums;

namespace FinControl.API.ViewModels;

public class RecurrenceViewModel : ViewModelBase
{
    public int Installment { get; set; }
    public RecurringFrequency Frequency { get; set; }

    public Recurrence ToModel()
    {
        return new Recurrence
        {
            Installment = Installment,
            Frequency = Frequency
        };
    }
}