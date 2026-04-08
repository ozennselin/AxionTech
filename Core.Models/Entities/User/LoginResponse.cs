namespace Core.Models.Entities.User;

public class LoginResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Rule{ get; set; }
    //Login işlemi için kullanıcı giriş tarihi bilgilerini ayrıca bir tabloda(Log'ta olabilir) tutabiliriz. Örneğin, son giriş tarihi, toplam giriş sayısı gibi bilgileri ekleyebiliriz.

}
