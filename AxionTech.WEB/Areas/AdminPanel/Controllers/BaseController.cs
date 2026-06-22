using AxionTech.WEB.GetApi;
using Core.Models.Entities.MenuRole;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers
{
    public class BaseController : Controller
    {
        private readonly MenuRoleApi _menuRoleApi;
        private readonly RoleApi _roleApi;
        private readonly UserApi _userApi;
        private List<MenuRoleResponseModel> menuRoleList=new List<MenuRoleResponseModel>();

        public BaseController(MenuRoleApi menuRoleApi,  UserApi userApi , RoleApi roleApi = null)
        {
            _menuRoleApi = menuRoleApi;
            _roleApi = roleApi;
            _userApi = userApi;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var adminSession = HttpContext.Session.GetString("AdminPanelUserName");

            if (string.IsNullOrEmpty(adminSession))
            {
                context.Result = new RedirectToActionResult(
                    "Login",
                    "AdminLoginAP",
                    new { area = "AdminPanel" });
            }
            else
            {
                //Sen hangi roldesin, list olarak RoleId leri getireceğim
                int getUserId = Convert.ToInt32(HttpContext.Session.GetInt32("AdminPanelUserId"));
                var getRole= _userApi.GetById(getUserId);//
                var getMenuRole = _menuRoleApi.List((int)(getRole.RoleId));
                //Cookie => harici bellek tutucu=>
                GetMenuRoleList((int)getRole.RoleId, out menuRoleList);

            }
        }


        public List<MenuRoleResponseModel> GetMenuRoleList(  int roleId, out List<MenuRoleResponseModel> menuRoleList)
        {
            menuRoleList= _menuRoleApi.List(roleId);

            return menuRoleList;
        }
    }
}
