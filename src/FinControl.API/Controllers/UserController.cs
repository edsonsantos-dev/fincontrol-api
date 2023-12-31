using FinControl.API.ViewModels;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;

namespace FinControl.API.Controllers;

public class UserController(
    INotifier notifier,
    IUserRepository repository,
    IGenericService<UserValidation, User> service)
    : GenericController<UserViewModel, User, UserValidation>(notifier, repository, service);