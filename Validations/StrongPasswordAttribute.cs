using System.ComponentModel.DataAnnotations;
using System.Net.Security;

namespace Server.Validation;

public class StrongPasswordAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if(value is not string password)
          return false;

        return password.Any(c => c is >= '0' and <= '9') &&
            password.Any(c => c >= 'A' && c <= 'Z') &&
            password.Any(c => c >= 'a' && c <= 'z');
    }

    public override string FormatErrorMessage(string name)
    =>  $"The field {name} must has a number, a lowercase and uppercase letter";
}