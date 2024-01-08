using FinControl.API.ViewModels;
using FinControl.API.ViewModels.InputViewModels;
using FinControl.API.ViewModels.OutputViewModels;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;

namespace FinControl.API.Controllers;

public class CategoryController(
    INotifier notifier,
    IRepository<Category> repository,
    IGenericService<CategoryValidation, Category> service)
    : GenericController<CategoryInputViewModel, CategoryOutputViewModel, Category, CategoryValidation>
        (notifier, repository, service);