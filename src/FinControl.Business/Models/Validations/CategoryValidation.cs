using FluentValidation;

namespace FinControl.Business.Models.Validations;

public class CategoryValidation : ValidatorBase<Category>
{
    public CategoryValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(IfNullOrEmptyMessage)
            .Length(3, 20).WithMessage(LengthMessage);
    }
}