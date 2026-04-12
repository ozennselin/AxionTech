namespace Core.Models.Entities.User;

public class UserLoginModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string? Token { get; set; } = null;
    //Identity, JWT konusu token işlenecek
    //session, cookie konuları analatacağım
}
