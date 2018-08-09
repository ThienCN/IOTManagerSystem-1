using IOTManagerSystem.Model.USER;
using IOTManagerSystem.Repository.USER;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IOTManagerSystem.Repository.PARAMETER;
using IOTManagerSystem.Repository.ROLE;

namespace IOTManagerSystem.Controllers
{
    [Authorize(Roles = "admin, employee")]
    public class ManagerUserController : CustomController
    {
        // GET: ManagerUser
        public ActionResult Index()
        {
            if (loginedUser == null)
                return View("Login");

            ViewBag.MaUser = loginedUser.ma_nguoi_dung;
            ViewBag.NameUser = loginedUser.ho_ten_nguoi_dung;
            ViewBag.ListGioiTinh = new PARAMETERRepository().GetListGioiTinh();
            ViewBag.ListRole = new ROLERepository().GetAll();
            return View("ManagerUser");
        }

        public ActionResult ManagerUser()
        {
            if (loginedUser == null)
                return View("Login");

            ViewBag.MaUser = loginedUser.ma_nguoi_dung;
            ViewBag.NameUser = loginedUser.ho_ten_nguoi_dung;
            ViewBag.ListGioiTinh = new PARAMETERRepository().GetListGioiTinh();
            ViewBag.ListRole = new ROLERepository().GetAll();
            return View("AdminManagerUser");
        }

        public ActionResult ReadUsers([DataSourceRequest]DataSourceRequest request)
        {
            IEnumerable<USERModel> list = new USERRepository().GetAll();
            return Json(list.ToDataSourceResult(request));
        }
    }
}