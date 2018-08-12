using IOTManagerSystem.API;
using IOTManagerSystem.Repository.USER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOTManagerSystem.Controllers
{
    [Authorize(Roles = "employee")]
    public class PageEmployeeController : CustomController
    {
        // GET: PageEmployee
        public ActionResult Index()
        {
            if (loginedUser == null)
                return View("Login");

            ViewBag.MaUser = loginedUser.ma_nguoi_dung;
            ViewBag.NameUser = loginedUser.ho_ten_nguoi_dung;

            ViewBag.InfoEmployee = new USERRepository().GetByMaUser(EncryptTo.Decrypt(loginedUser.ma_nguoi_dung));
            return View("PageEmployee");
        }
    }
}