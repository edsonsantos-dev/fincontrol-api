using FluentValidation;

namespace FinControl.Business.Models.Validations;

public class ValidatorBase<T> : AbstractValidator<T> where T : Entity
{
    internal const string IfNullOrEmptyMessage = "O campo {PropertyName} precisa ser fornecido";

    internal const string LengthMessage =
        "O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres";

    internal const string GreaterThanMessage = "O campo {PropertyName} precisa ser maior que {ComparisonValue}";
}