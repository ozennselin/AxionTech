using Core.Enums;
using Core.Models.Entities.Category;

namespace Business.Service.Interfaces;

public interface ICategoryService
{
    //Product ile ilgili operasyonlar burada yani service içinde  tanımlanacak
    //CRUD Insert, Update, Delete, Get, GetAll vs.
    //API katmanında bu operasyonlar çağırılacak ve Request /Response işlemleri yapılacak
    //Request=> istek, talepler
    //Response=> cevaplar, yanıtlar
    ResponseMessageEnum Create(CreateCategoryRequestModel request);
    ResponseMessageEnum Update(UpdateCategoryRequestModel request);
    ResponseMessageEnum Delete(DeleteCategoryRequestModel request);
    List<CategoryResponseModel> List();
    CategoryResponseModel? GetById(int id);
}
