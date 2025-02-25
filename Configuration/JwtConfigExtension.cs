using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Server.Configuration;


public static class JwtConfigExtension
{
    public static IServiceCollection AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidIssuer = "para-lanches",
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                IssuerSigningKey = configuration.GetJwtSecurityKey()
            };
        });

        services.AddAuthorization();
        return services;
    }
}