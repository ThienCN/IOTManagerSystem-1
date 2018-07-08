using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOTManagerSystem.Controllers
{
    public class PageUserController : Controller
    {
        // GET: PageUser
        public ActionResult Index()
        {
            return View("PageUser");
        }
    }
}