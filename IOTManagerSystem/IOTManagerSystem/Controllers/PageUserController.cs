using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IOTManagerSystem.Controllers
{
    [Authorize(Roles = "employee")]
    public class PageUserController : Controller
    {
        // GET: PageUser
        public ActionResult Index()
        {
            ViewBag.NameUser = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            return View("PageUser");
        }
    }
}