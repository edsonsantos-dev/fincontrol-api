using FluentValidation;

namespace FinControl.Business.Models.Validations;

public class UserValidation : ValidatorBase<User>
{
    public UserValidation()
    {
        ApplyRules();
    }

    protected sealed override void ApplyRules()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage(IfNullOrEmptyMessage)
            .Length(3, 50).WithMessage(LengthMessage);

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage(IfNullOrEmptyMessage)
            .Length(3, 50).WithMessage(LengthMessage);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(IfNullOrEmptyMessage)
            .Length(3, 100).WithMessage(LengthMessage);

        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage(IfNullOrEmptyMessage);
    }
}