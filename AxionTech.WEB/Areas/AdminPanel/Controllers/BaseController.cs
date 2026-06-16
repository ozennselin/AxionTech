using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers
{
    public class BaseController : Controller
    {

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

            base.OnActionExecuting(context);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
