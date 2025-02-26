namespace Server.Entities;

public class ApplicationMeal
{
    public Guid Id { get; set;} = Guid.NewGuid();
    public required string Name { get; set;}
    public required string Description { get; set;}
    public required float Price { get; set;}
    public ICollection<ApplicationOrder>? Orders { get; set;}

}