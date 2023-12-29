using FinControl.Business.Models;
using FinControl.Data.Context;

namespace FinControl.Data.Repository;

public class AccountRepository(FinControlContext context) : Repository<Account>(context);