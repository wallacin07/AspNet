using Server.Entities;

namespace Server.Services.Token;

public interface ITokenService
{
    string Generate(ApplicationUser user);
}