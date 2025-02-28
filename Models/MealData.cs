using System.ComponentModel.DataAnnotations;

public record MealData(
    [Required]
    string Name,
    [Required]
    string Description,
    [Required]
    float Price
){}