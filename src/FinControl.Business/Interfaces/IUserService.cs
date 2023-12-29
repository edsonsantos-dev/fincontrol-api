using FinControl.Business.Models;
using FinControl.Business.Models.Validations;

namespace FinControl.Business.Interfaces;

public interface IUserService : IGenericService<UserValidation, User>
{
    void GeneretePasswordHash(User model);
}