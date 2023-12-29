using FinControl.Business.Models;
using FinControl.Data.Context;

namespace FinControl.Data.Repository;

public class CategoryRepository(FinControlContext context) : Repository<Category>(context);