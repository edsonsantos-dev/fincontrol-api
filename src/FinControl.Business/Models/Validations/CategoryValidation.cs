using FluentValidation;

namespace FinControl.Business.Models.Validations;

public class CategoryValidation : ValidatorBase<Category>
{
    public CategoryValidation()
    {
        ApplyRules();
    }

    protected sealed override void ApplyRules()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(IfNullOrEmptyMessage)
            .Length(3, 20).WithMessage(LengthMessage);
    }
}