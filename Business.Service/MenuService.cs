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

    public MenuResponseModel GetById(int id)
    {
        var menu = _menuRepository.GetById(id);

        if (menu == null)
        {
            return null;
        }

        return new MenuResponseModel
        {
            Id = menu.Id,
            ControllerName = menu.ControllerName,
            ParentId = menu.ParentId,
            ViewName = menu.ViewName,
            IsActive = menu.IsActive
        };
    }
    public ResponseMessageEnum Update(UpdateMenuRequestModel request)
    {
        try
        {
            var menuToUpdate = _menuRepository.GetById(request.Id);

            if (menuToUpdate == null)
            {
                return ResponseMessageEnum.NotFound;
            }

            menuToUpdate.ControllerName = request.ControllerName;
            menuToUpdate.ParentId = request.ParentId;
            menuToUpdate.ViewName = request.ViewName;
            menuToUpdate.IsActive = request.IsActive;

            _menuRepository.Update(menuToUpdate);

            return ResponseMessageEnum.UpdateSuccess;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.UpdateErrorWithMessage;
        }
    }
    public ResponseMessageEnum Delete(DeleteMenuRequestModel request)
    {
        try
        {
            var menuToDelete = _menuRepository.GetById(request.Id);

            if (menuToDelete == null)
            {
                return ResponseMessageEnum.NotFound;
            }

            _menuRepository.Delete(menuToDelete);

            return ResponseMessageEnum.Success;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.DeleteError;
        }
    }
}
