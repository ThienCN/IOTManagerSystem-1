using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOTManagerSystem.Controllers
{

    public class ManagerEmployeeController : CustomController
    {
        // GET: ManagerEmployee
        public ActionResult Index()
        {
            if (loginedUser == null)
                return View("Login");

            ViewBag.MaUser = loginedUser.ma_nguoi_dung;
            ViewBag.NameUser = loginedUser.ho_ten_nguoi_dung;
            return View("ManagerEmployee");
        }
    }
}