namespace Server.Services.Password;

public interface  IPasswordService
{
    public string Hash(string password);

    public bool Verify(string password, string hashedPass);
}