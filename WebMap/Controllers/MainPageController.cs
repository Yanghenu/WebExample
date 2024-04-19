using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WebMap.BLL;
using WebMap.Models;

namespace WebMap.Controllers
{
    public class MainPageController : Controller
    {
        LocationDataBLL bll = new LocationDataBLL();
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult InsertUserInfo([FromBody] UserInfo model)
        {
            int result = bll.InsertUserInfo(model);
            return Json(result);
        }

        public JsonResult GetOtherUserInfo()
        {
            var list = bll.GetOtherUserInfo();
            return Json(list);
        }

        public JsonResult UpdateStatus([FromBody] UserInfo model)
        {
            string jsonString = JsonConvert.SerializeObject(model);
            bll.UpdateUserInfo(jsonString);
            return Json(1);
        }
    }
}
