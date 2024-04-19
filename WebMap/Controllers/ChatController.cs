using Microsoft.AspNetCore.Mvc;

namespace WebMap.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
