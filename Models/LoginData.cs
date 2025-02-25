using System.ComponentModel.DataAnnotations;

namespace Server.Models;

public record LoginData(
    [Required]
    string Login,
    [Required]
    [MinLength(8)]
    string Password
){}