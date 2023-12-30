using System.Net;
using FinControl.API.ViewModels;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;
using Microsoft.AspNetCore.Mvc;

namespace FinControl.API.Controllers;

public class TransactionController(
    INotifier notifier,
    ITransactionRepository repository,
    IGenericService<TransactionValidation, Transaction> service)
    : GenericController<TransactionViewModel, Transaction, TransactionValidation>(notifier, repository, service)
{
    [HttpGet(nameof(GetTransactionsAsync))]
    public async Task<IActionResult> GetTransactionsAsync(Guid accountId)
    {
        var models = await repository.GetTransactionsAsync(accountId);

        var viewModels = models.Select(TransactionViewModel.FromModel);

        return CustomResponse(HttpStatusCode.OK, viewModels);
    }

    [HttpGet(nameof(GetTransactionByIdAsync))]
    public async Task<IActionResult> GetTransactionByIdAsync(Guid id)
    {
        var model = await repository.GetTransactionByIdAsync(id);

        var viewModel = TransactionViewModel.FromModel(model);

        return viewModel != null
            ? CustomResponse(HttpStatusCode.OK, viewModel)
            : CustomResponse(HttpStatusCode.NoContent);
    }
}