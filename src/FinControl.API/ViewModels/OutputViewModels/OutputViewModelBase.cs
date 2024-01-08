using FinControl.Business.Models;

namespace FinControl.API.ViewModels.OutputViewModels;

public abstract class OutputViewModelBase<TEntity> : ViewModelBase where TEntity : Entity
{
    public DateTime AddedOn { get; set; }
    public Guid AddedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public Guid? ModifiedBy { get; set; }

    public abstract TOutputViewModel FromModel<TOutputViewModel>(TEntity model)
        where TOutputViewModel : OutputViewModelBase<TEntity>;
}