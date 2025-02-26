namespace Server.Entities;

public class ApplicationOrder
{
    public Guid Id { get; set;} = Guid.NewGuid();
    public Guid CustomerId { get; set; }
    public required ApplicationUser Customer { get; set;}
    public ICollection<ApplicationMeal> Meals { get; set;} = [];
    public ICollection<ApplicationDrink> Drinks { get; set;} = [];
    public required float TotalPrice {get; set;}
    public bool OrderCompleted { get; set;} = false;

}