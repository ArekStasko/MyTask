namespace MyTask.IdP.Data.Models;

public interface IUser
{
    public string UserName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string Token { get; set; }
}