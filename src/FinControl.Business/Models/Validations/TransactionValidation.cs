using FluentValidation;

namespace FinControl.Business.Models.Validations;

public class TransactionValidation : ValidatorBase<Transaction>
{
    public TransactionValidation()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(IfNullOrEmptyMessage)
            .Length(3, 20).WithMessage(LengthMessage);

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage(GreaterThanMessage);
    }
}