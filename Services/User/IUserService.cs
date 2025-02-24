namespace Server.Services.User;

using Entities;
using Models;


public interface IUserService
{
    Task<ApplicationUser> CreateUser(AccountData data);
    Task<ApplicationUser> CreateUser(AccountData data, Guid invitedByUserId);
    Task<ApplicationUser?> Authenticate(LoginData data);
}