using FinControl.Shared.Enums;

namespace FinControl.Shared.Extensions;

public static class DateTimeExtensions
{
    public static DateTime AddWeeks(this DateTime dateTime, int weeks)
    {
        return dateTime.AddDays(weeks * 7);
    }
    
    public static DateTime AddFortnights(this DateTime dateTime, int fortnights)
    {
        return dateTime.AddDays(fortnights * 15);
    }
    
    public static DateTime AddBimonthly(this DateTime dateTime, int bimonthly)
    {
        return dateTime.AddMonths(bimonthly * 2);
    }
    
    public static DateTime AddQuarters(this DateTime dateTime, int quarters)
    {
        return dateTime.AddMonths(quarters * 3);
    }
    
    public static DateTime AddHalfYears(this DateTime dateTime, int halfYears)
    {
        return dateTime.AddMonths(halfYears * 6);
    }
    
    public static DateTime CalculateNextDueDate(this DateTime dueDate, RecurringFrequency frequency, int installment)
    {
        return frequency switch
        {
            RecurringFrequency.Daily => dueDate.AddDays(installment),
            RecurringFrequency.Weekly => dueDate.AddWeeks(installment),
            RecurringFrequency.Fortnightly => dueDate.AddFortnights(installment),
            RecurringFrequency.Monthly => dueDate.AddMonths(installment),
            RecurringFrequency.Bimonthly => dueDate.AddBimonthly(installment),
            RecurringFrequency.Quarterly => dueDate.AddQuarters(installment),
            RecurringFrequency.HalfYearly => dueDate.AddHalfYears(installment),
            RecurringFrequency.Yearly => dueDate.AddYears(installment),
            _ => dueDate.AddMonths(installment)
        };
    }
}