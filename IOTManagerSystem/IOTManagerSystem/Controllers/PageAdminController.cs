using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOTManagerSystem.Controllers
{
    public class PageAdminController : Controller
    {
        // GET: PageAdmin
        public ActionResult Index()
        {
            return View("PageAdmin");
        }
    }
}