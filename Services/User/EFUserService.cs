namespace Server.Services.User;

using Entities;
using Microsoft.EntityFrameworkCore;
using Models;
using Server.Services.Password;

public class EFUserService(
    ParaLanchesDbContext ctx,
    IPasswordService hasher
    ) : IUserService
{
    public async Task<ApplicationUser?> Authenticate(LoginData data)
    {
        var users = 
        from user in ctx.Users
        where user.Name == data.Login || user.Email == data.Login
        select user;

        return await users.FirstOrDefaultAsync() switch {
            ApplicationUser user when hasher.Verify(data.Password, user.PasswordHash) => user, _ => null
        };


    }

    public async Task<ApplicationUser> CreateUser(AccountData data)
    {
        var user = new ApplicationUser{
            Email = data.Email,
            Name = data.Name,
            PasswordHash = hasher.Hash(data.Password)
        };

        ctx.Add(user);
        await ctx.SaveChangesAsync();

        return user;
    }

    public async Task<ApplicationUser> CreateUser(AccountData data, Guid invitedByUserId)
    {
             var user = new ApplicationUser{
            Email = data.Email,
            Name = data.Name,
            PasswordHash = hasher.Hash(data.Password),
            InvitedById = invitedByUserId
        };

        ctx.Add(user);
        await ctx.SaveChangesAsync();

        return user;
    }
}
