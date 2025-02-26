using Server.Entities;

namespace Server.Models;

public record OrderData(
    ApplicationDrink[] drinks,
    ApplicationMeal[] meals,
    ApplicationUser customer,
    float totalPrice
){}