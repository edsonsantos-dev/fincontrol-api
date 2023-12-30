using FinControl.API.ViewModels;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;

namespace FinControl.API.Controllers;

public class AccountController(
    INotifier notifier,
    IRepository<Account> repository,
    IGenericService<AccountValidation, Account> service)
    : GenericController<AccountViewModel, Account, AccountValidation>(notifier, repository, service);