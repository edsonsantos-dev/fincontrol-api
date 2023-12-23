using FluentValidation;

namespace FinControl.Business.Models.Validations;

public class AccountValidation : ValidatorBase<Account>
{
    public AccountValidation()
    {
        ApplyRules();
    }
    
    protected sealed override void ApplyRules()
    {
        RuleFor(x => x.Users)
            .Must(list => list != null && list.Count != 0)
            .WithMessage("É necessário ter pelo menos um usuário associado à conta.");
    }
}