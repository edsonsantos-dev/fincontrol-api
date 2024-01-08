using FinControl.Business.Models;

namespace FinControl.API.ViewModels.InputViewModels;

public class CategoryInputViewModel : InputViewModelBase<Category>
{
    public required string Name { get; set; }
    public bool IsActive { get; set; }
    
    public override Category ToModel()
    {
        return new Category
        {
            Name = Name,
            IsActive = IsActive
        };
    }
}