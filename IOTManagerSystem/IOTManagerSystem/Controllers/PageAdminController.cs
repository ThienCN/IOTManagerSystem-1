using IOTManagerSystem.API;
using IOTManagerSystem.Repository.ROLE;
using IOTManagerSystem.Repository.USER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IOTManagerSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class PageAdminController : CustomController
    {
        // GET: PageAdmin
        public ActionResult Index()
        {
            if(loginedUser == null)
                return View("Login");

            ViewBag.MaUser = loginedUser.ma_nguoi_dung;
            ViewBag.NameUser = loginedUser.ho_ten_nguoi_dung;

            ViewBag.InfoAdmin = new USERRepository().GetByMaUser(EncryptTo.Decrypt(loginedUser.ma_nguoi_dung));
            ViewBag.ListRole = new ROLERepository().GetAll();
            return View("PageAdmin");
        }
    }
}