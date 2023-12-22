namespace FinControl.Business.Models;

public class Category : Entity
{
    public string Name { get; set; }

    public List<Transaction> Transactions { get; set; }
}