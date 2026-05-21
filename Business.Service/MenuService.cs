using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.Menu;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

namespace Business.Service;

public class MenuService : IMenuService
{
    private readonly IMenuRepository _menuRepository;

    public MenuService(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }
  
    public (ResponseMessageEnum , CreateMenuRequestModel) Create(CreateMenuRequestModel request)
    {

        try
        {
            var existMenu = _menuRepository.GetEntityQuery(k=>k.ControllerName==request.ControllerName && k.ViewName==request.ViewName);

            if (existMenu!=null)
            {
                return (ResponseMessageEnum.Exist,request);
            }
            Menu menuCreate = new Menu();

            menuCreate.ControllerName = request.ControllerName;
            menuCreate.ParentId = request.ParentId;
            menuCreate.IsActive= request.IsActive;
            menuCreate.ViewName= request.ViewName;
            menuCreate.UpdateDate = DateTime.Now;
            menuCreate.UpdaterId = 1;//Session Login olan kullanıcını Id 'si gelecek
            menuCreate.IsActive = true;

            _menuRepository.Add(menuCreate);

            return (ResponseMessageEnum.Success,null);
        }
        catch (Exception)
        {
            return (ResponseMessageEnum.UpdateErrorWithMessage,null);
        }


    }
    public List<MenuResponseModel> List()
    {
        var menuList = _menuRepository.GetAll().ToList();

        return menuList.Select(x => new MenuResponseModel
        {
            Id = x.Id,
            ControllerName = x.ControllerName,
            ParentId = x.ParentId,
            ViewName = x.ViewName,
            IsActive = x.IsActive
        }).ToList();
    }
}
