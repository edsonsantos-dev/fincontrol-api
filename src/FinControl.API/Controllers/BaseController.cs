using System.Net;
using FinControl.API.ViewModels;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Notifications;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FinControl.API.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class BaseController<TViewModel, TEntity, TValidation>(
    INotifier notifier,
    IRepository<TEntity> repository,
    IGenericService<TValidation, TEntity> service) : ControllerBase
    where TEntity : Entity
    where TViewModel : ViewModelBase<TEntity>
    where TValidation : AbstractValidator<TEntity>
{
    [HttpPost]
    protected virtual async Task<IActionResult> Add(TViewModel viewModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var model = viewModel.ToModel();
        await service.AddAsync(model);
        return CustomResponse(HttpStatusCode.Created, viewModel);
    }

    [HttpPut]
    protected virtual async Task<IActionResult> Update(TViewModel viewModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var model = viewModel.ToModel();
        await service.UpdateAsync(model);
        return CustomResponse(HttpStatusCode.OK, viewModel);
    }

    [HttpGet]
    protected virtual async Task<IActionResult> Get(Guid id)
    {
        var model = await repository.GetByIdAsync(id);

        return model != null ? CustomResponse(HttpStatusCode.OK, model) : CustomResponse(HttpStatusCode.NoContent);
    }

    [HttpDelete]
    protected virtual async Task<IActionResult> Remove(Guid id)
    {
        await service.RemoveAsync(id);
        return CustomResponse(HttpStatusCode.NoContent);
    }

    private bool IsValid()
    {
        return !notifier.HaveNotification();
    }

    protected IActionResult CustomResponse(
        HttpStatusCode statusCode = HttpStatusCode.OK,
        object result = null)
    {
        if (IsValid())
            return new ObjectResult(result)
            {
                StatusCode = Convert.ToInt32(statusCode)
            };

        return BadRequest(new
        {
            Errors = notifier.GetNotifications().Select(x => x.Message)
        });
    }

    private IActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid) NotifyErrorInvalidModel(modelState);
        return CustomResponse();
    }

    private void NotifyErrorInvalidModel(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(e => e.Errors);

        foreach (var error in errors)
        {
            var message = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
            NotifyError(message);
        }
    }

    private void NotifyError(string message)
    {
        notifier.AddNotification(new Notification(message));
    }
}