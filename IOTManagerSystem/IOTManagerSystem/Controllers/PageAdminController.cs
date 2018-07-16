using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IOTManagerSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class PageAdminController : Controller
    {
        // GET: PageAdmin
        public ActionResult Index()
        {
            ViewBag.NameUser = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            return View("PageAdmin");
        }
    }
}