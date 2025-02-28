using System.ComponentModel.DataAnnotations;

public record DrinkData(
    [Required]
    string Name,
    [Required]
    string Description,
    [Required]
    float Price
){}