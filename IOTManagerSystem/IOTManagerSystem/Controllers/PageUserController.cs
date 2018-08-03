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

namespace IOTManagerSystem.Controllers
{
    [Authorize(Roles = "employee")]
    public class PageUserController : Controller
    {
        // GET: PageUser
        public ActionResult Index()
        {
            var temp = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            ViewBag.MaUser = EncryptTo.Encrypt(temp.Split('_')[0]);
            ViewBag.NameUser = temp.Split('_')[1];

            return View("PageUser");
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            IEnumerable<USERModel> list = new USERRepository().GetAll();
            return Json(list.ToDataSourceResult(request));
        }
    }
}