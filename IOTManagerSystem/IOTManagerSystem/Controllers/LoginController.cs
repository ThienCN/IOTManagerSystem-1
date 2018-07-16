using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IOTManagerSystem.Model;
using IOTManagerSystem.Model.USER;
using IOTManagerSystem.Model.ACCOUNT;
using IOTManagerSystem.Repository.USER;

namespace IOTManagerSystem.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        [AllowAnonymous]
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult SaveLogin(int id_account)
        {
            ACCOUNTModel account = new ACCOUNTModel();
            account.id = id_account;
            USERModel user = new USERRepository().GetUSERByIdAccount(account);

            //FormsAuthentication.SetAuthCookie("abc", false);

            //rememberMe: tự nhớ ho_ten_nguoi_dung của lần trước để tự động đăng nhập hay không?
            bool rememberMe = false;
            var authTicket = new FormsAuthenticationTicket(
                            1,                             // version
                            user.ho_ten_nguoi_dung,        // user name
                            DateTime.Now,                  // created
                            DateTime.Now.AddMinutes(20),   // expires
                            rememberMe,                    // persistent?
                            user.ma_role,                  // can be used to store roles
                            "/"
                            );

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);

            return Json(user, JsonRequestBehavior.AllowGet);

            //FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);
            //return ticket.Name;
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }




    }
}