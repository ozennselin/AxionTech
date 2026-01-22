using Core.Models.Entities.Category;

namespace Business.Service.Interfaces;

public interface ICategoryService
{
    //Product ile ilgili operasyonlar burada yani service içinde  tanımlanacak
    //CRUD Insert, Update, Delete, Get, GetAll vs.
    //API katmanında bu operasyonlar çağırılacak ve Request /Response işlemleri yapılacak
    //Request=> istek, talepler
    //Response=> cevaplar, yanıtlar

    void Create(CreateCategoryRequestModel request);
    void Update(UpdateCategoryRequestModel request);
    void Delete(DeleteCategoryRequestModel request);
    List<CategoryResponseModel> List();
}
