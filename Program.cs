using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Server;
using Server.Configuration;
using Server.Entities;
using Server.Services.Drink;
using Server.Services.Meal;
using Server.Services.Order;
using Server.Services.Password;
using Server.Services.Token;
using Server.Services.User;

var builder = WebApplication.CreateBuilder(args);



builder.Services
    .AddJWTAuthentication(builder.Configuration)
    .AddDbContext<ParaLanchesDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
        ));

builder.Services
    .AddSingleton(builder.Configuration)
    .AddSingleton<IPasswordService, PBKDF2PasswordService>()
    .AddSingleton<ITokenService, JWTService>()
    .AddScoped<IUserService, EFUserService>()
    .AddScoped<IOrderService,EFOrderService>()
    .AddScoped<IMealService,EFMealService>()
    .AddScoped<IDrinkService,EFDrinkService>();

// tipos de tempo de vida
// builder.Services
// .AddSingleton()
// .AddTransient()
// .AddScoped()

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
