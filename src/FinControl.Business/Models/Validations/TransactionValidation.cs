﻿using FluentValidation;

namespace FinControl.Business.Models.Validations;

public class TransactionValidation : ValidatorBase<Transaction>
{
    public TransactionValidation()
    {
        ApplyRules();
    }

    protected sealed override void ApplyRules()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(IfNullOrEmptyMessage)
            .Length(3, 100).WithMessage(LengthMessage);

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage(GreaterThanMessage);
    }
}