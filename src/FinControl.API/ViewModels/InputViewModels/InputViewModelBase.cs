using FinControl.Business.Models;

namespace FinControl.API.ViewModels.InputViewModels;

public abstract class InputViewModelBase<TEntity> : ViewModelBase where TEntity : Entity
{
    public abstract TEntity ToModel();
}