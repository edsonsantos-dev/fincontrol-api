using System.Net;
using FinControl.API.ViewModels;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinControl.API.Controllers;

public abstract class GenericController<TViewModel, TEntity, TValidation>(
    INotifier notifier,
    IRepository<TEntity> repository,
    IGenericService<TValidation, TEntity> service) : BaseController(notifier)
    where TEntity : Entity
    where TViewModel : ViewModelBase<TEntity>
    where TValidation : AbstractValidator<TEntity>
{
    [HttpPost]
    [Authorize(Roles = "Owner, Contributor")]
    public virtual async Task<IActionResult> Add(TViewModel viewModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var model = viewModel.ToModel();
        await service.AddAsync(model);
        return CustomResponse(HttpStatusCode.Created, viewModel);
    }

    [HttpPut]
    [Authorize(Roles = "Owner, Contributor")]
    public virtual async Task<IActionResult> Update(TViewModel viewModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var model = viewModel.ToModel();
        await service.UpdateAsync(model);
        return CustomResponse(HttpStatusCode.OK, viewModel);
    }

    [HttpGet]
    [Authorize(Roles = "Owner, Contributor, Viewer")]
    public virtual async Task<IActionResult> Get(Guid id)
    {
        var model = await repository.GetByIdAsync(id);

        return model != null ? CustomResponse(HttpStatusCode.OK, model) : CustomResponse(HttpStatusCode.NoContent);
    }

    [HttpDelete]
    [Authorize(Roles = "Owner, Contributor")]
    public virtual async Task<IActionResult> Remove(Guid id)
    {
        await service.RemoveAsync(id);
        return CustomResponse(HttpStatusCode.NoContent);
    }
}