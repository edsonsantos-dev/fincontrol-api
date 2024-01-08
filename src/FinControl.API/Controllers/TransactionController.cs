using System.Net;
using FinControl.API.ViewModels;
using FinControl.API.ViewModels.InputViewModels;
using FinControl.API.ViewModels.OutputViewModels;
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
    : GenericController<TransactionInputViewModel, TransactionOutputViewModel, Transaction, TransactionValidation>
        (notifier, repository, service)
{
    [HttpGet(nameof(GetTransactionsAsync))]
    [Authorize(Roles = "Owner, Contributor, Viewer")]
    public async Task<IActionResult> GetTransactionsAsync()
    {
        try
        {
            var models = await repository.GetTransactionsAsync();

            var viewModels =
                models.Select(new TransactionOutputViewModel().FromModel<TransactionOutputViewModel>);

            return CustomResponse(HttpStatusCode.OK, viewModels);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet(nameof(GetTransactionByIdAsync))]
    [Authorize(Roles = "Owner, Contributor, Viewer")]
    public async Task<IActionResult> GetTransactionByIdAsync(Guid id)
    {
        var model = await repository.GetTransactionByIdAsync(id);

        var viewModel = new TransactionOutputViewModel().FromModel<TransactionOutputViewModel>(model);

        return viewModel != null
            ? CustomResponse(HttpStatusCode.OK, viewModel)
            : CustomResponse(HttpStatusCode.NoContent);
    }
}