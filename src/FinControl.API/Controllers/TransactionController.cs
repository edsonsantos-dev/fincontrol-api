using System.Net;
using FinControl.API.ViewModels;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinControl.API.Controllers;

public class TransactionController(
    INotifier notifier,
    ITransactionRepository repository,
    IGenericService<TransactionValidation, Transaction> service)
    : GenericController<TransactionViewModel, Transaction, TransactionValidation>(notifier, repository, service)
{
    [HttpGet(nameof(GetTransactionsAsync))]
    [Authorize(Roles = "Owner, Contributor, Viewer")]
    public async Task<IActionResult> GetTransactionsAsync()
    {
        var models = await repository.GetTransactionsAsync();

        var viewModels = models.Select(TransactionViewModel.FromModel);

        return CustomResponse(HttpStatusCode.OK, viewModels);
    }

    [HttpGet(nameof(GetTransactionByIdAsync))]
    [Authorize(Roles = "Owner, Contributor, Viewer")]
    public async Task<IActionResult> GetTransactionByIdAsync(Guid id)
    {
        var model = await repository.GetTransactionByIdAsync(id);

        var viewModel = TransactionViewModel.FromModel(model);

        return viewModel != null
            ? CustomResponse(HttpStatusCode.OK, viewModel)
            : CustomResponse(HttpStatusCode.NoContent);
    }
}