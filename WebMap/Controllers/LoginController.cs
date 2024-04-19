using Microsoft.AspNetCore.Mvc;
using WebMap.BLL;
using WebMap.Models;

namespace WebMap.Controllers
{
    public class LoginController : Controller
    {
        LoginBLL bll = new LoginBLL();
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetAccount([FromBody] Account account)
        {
            var result = bll.GetAccounts(account.user, account.Password);

            return Json(result);
        }
    }
}
