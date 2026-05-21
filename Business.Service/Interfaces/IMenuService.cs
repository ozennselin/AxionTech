using Core.Enums;
using Core.Models.Entities.Cart;
using Core.Models.Entities.Menu;

namespace Business.Service.Interfaces;

public interface IMenuService
{
    (ResponseMessageEnum, CreateMenuRequestModel) Create(CreateMenuRequestModel request);
    List<MenuResponseModel> List();
}
