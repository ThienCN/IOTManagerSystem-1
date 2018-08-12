using IOTManagerSystem.Repository.USER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IOTManagerSystem.API;
using IOTManagerSystem.Model.USER;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Globalization;
using IOTManagerSystem.Repository.ROLE;

namespace IOTManagerSystem.Controllers
{
    [Authorize(Roles = "user")]
    public class PageUserController : CustomController
    {
        // GET: PageUser
        public ActionResult Index()
        {
            if (loginedUser == null)
                return View("Login");

            ViewBag.MaUser = loginedUser.ma_nguoi_dung;
            ViewBag.NameUser = loginedUser.ho_ten_nguoi_dung;

            ViewBag.InfoUser = new USERRepository().GetByMaUser(EncryptTo.Decrypt(loginedUser.ma_nguoi_dung));
            return View("PageUser");
        }

        

        [HttpPost]
        public ActionResult UpdateProfile(USERModel user)
        {
            if (new USERRepository().Update(user))
                return Json(new { success = true, user = user });
            else return Json(new { success = false });
        }
    }
}