using FinControl.API.ViewModels;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;
using Microsoft.AspNetCore.Mvc;

namespace FinControl.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController(
    INotifier notifier,
    ITransactionRepository repository,
    IGenericService<TransactionValidation, Transaction> service)
    : BaseController<TransactionViewModel, Transaction, TransactionValidation>(notifier, repository, service)
{
}