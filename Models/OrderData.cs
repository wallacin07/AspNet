using System.ComponentModel.DataAnnotations;
using Server.Entities;

namespace Server.Models;

public record OrderData(
    [Required]
    string[] drinks,
    [Required]
    string[] meals,
    [Required]
    string CustomerId,
    [Required]
    float totalPrice
){}