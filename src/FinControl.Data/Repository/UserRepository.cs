using FinControl.Business.Models;
using FinControl.Data.Context;

namespace FinControl.Data.Repository;

public class UserRepository(FinControlContext context) : Repository<User>(context);