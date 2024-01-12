using System.Net;
using FinControl.API.ViewModels.InputViewModels;
using FinControl.API.ViewModels.OutputViewModels;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinControl.API.Controllers;

public abstract class GenericController<
    TInputViewModel,
    TOutputViewModel,
    TEntity,
    TValidation>(
    INotifier notifier,
    IRepository<TEntity> repository,
    IGenericService<TValidation, TEntity> service) : BaseController(notifier)
    where TEntity : Entity
    where TInputViewModel : InputViewModelBase<TEntity>
    where TOutputViewModel : OutputViewModelBase<TEntity>, new()
    where TValidation : AbstractValidator<TEntity>
{
    [HttpPost]
    [Authorize(Roles = "Owner, Contributor")]
    public virtual async Task<IActionResult> Add(TInputViewModel viewModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var model = viewModel.ToModel();

        model = await service.AddAsync(model);

        return CustomResponse(
            HttpStatusCode.Created,
            new TOutputViewModel().FromModel<TOutputViewModel>(model));
    }

    [HttpPut]
    [Authorize(Roles = "Owner, Contributor")]
    public virtual async Task<IActionResult> Update(TInputViewModel viewModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var model = viewModel.ToModel();
         
        model = await service.UpdateAsync(model);
        
        return CustomResponse(
            HttpStatusCode.OK,
            new TOutputViewModel().FromModel<TOutputViewModel>(model));
    }

    [HttpGet]
    [Authorize]
    public virtual async Task<IActionResult> Get(Guid id)
    {
        var model = await repository.GetByIdAsync(id);

        if (model == null) return CustomResponse(HttpStatusCode.NoContent);

        var outputViewModel = new TOutputViewModel();

        return CustomResponse(
            HttpStatusCode.OK,
            outputViewModel.FromModel<TOutputViewModel>(model)!);
    }

    [HttpDelete]
    [Authorize(Roles = "Owner, Contributor")]
    public virtual async Task<IActionResult> Remove(Guid id)
    {
        await service.RemoveAsync(id);
        return CustomResponse(HttpStatusCode.NoContent);
    }
}