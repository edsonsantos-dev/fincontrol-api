using FinControl.API.ViewModels;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinControl.API.Controllers;

public class AccountController(
    INotifier notifier,
    IRepository<Account> repository,
    IGenericService<AccountValidation, Account> service)
    : GenericController<AccountViewModel, Account, AccountValidation>(notifier, repository, service)
{
    [AllowAnonymous]
    public override Task<IActionResult> Add(AccountViewModel viewModel)
    {
        return base.Add(viewModel);
    }
}