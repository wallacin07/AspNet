using Microsoft.IdentityModel.Tokens;

namespace Server;

public static class ConfigurationExtension
{
    public static string GetClientUrl(this IConfiguration configuration)
    {
        const string key = "LocalUrl";
        var clientUrl = configuration[key]
            ?? throw new Exception($"Missing client url on appsettings.json with Key '{key}'.");
        return clientUrl;

    }

    public static string GetJWTSecret(this IConfiguration configuration)
    {
        const string key = "JWTSecret";
        var jwtSecret = configuration[key]
            ?? throw new Exception($"Missing jwt secret on appsettings.json with Key '{key}'.");
        return jwtSecret;

    }

    public static SymmetricSecurityKey GetJwtSecurityKey(this IConfiguration configuration)
    {
        var secretKey = configuration.GetJWTSecret();
        var secretBytes = Convert.FromBase64String(secretKey);
        return new SymmetricSecurityKey(secretBytes);
    }

}