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
using IOTManagerSystem.Repository.ACCOUNT;
using IOTManagerSystem.Model.ACCOUNT;
using System.Globalization;

namespace IOTManagerSystem.Controllers
{
    [Authorize(Roles = "employee")]
    public class PageUserController : CustomController
    {
        // GET: PageUser
        public ActionResult Index()
        {
            var temp = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            ViewBag.MaUser = loginedUser.ma_nguoi_dung;
            ViewBag.NameUser = loginedUser.ho_ten_nguoi_dung;
            USERModel user = new USERRepository().GetByMaUser(temp.Split('_')[0]);
            DateTime dt = DateTime.ParseExact(user.ngay_sinh, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            user.ngay_sinh = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            ViewBag.InfoUser = user;
            ViewBag.InfoAccount = new ACCOUNTRepository().GetByMaUser(temp.Split('_')[0]);
            return View("PageUser");
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            IEnumerable<USERModel> list = new USERRepository().GetAll();
            return Json(list.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult UpdateProfile(USERModel user)
        {
            var i = 0;
            return Json(new { success = true });
        }
    }
}