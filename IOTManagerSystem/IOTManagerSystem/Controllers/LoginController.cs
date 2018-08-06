﻿using System;
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
using IOTManagerSystem.Repository.ACCOUNT;
using IOTManagerSystem.API;
using System.Globalization;

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
            USERModel user = SaveLoginInfo(id_account);

            return Json(user, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult CheckAuthenticationGmail(string check)
        {
            //Kiểm tra DB
            var data = EncryptTo.Decrypt(check);
            if (!data.Contains("_"))
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            var arr = data.Split('_');
            var id_account = int.Parse(arr[0]); 
            var time = DateTime.ParseExact(arr[1], "ddMMyyyyHHmmss", CultureInfo.InvariantCulture);

            ACCOUNTModel account = new ACCOUNTRepository().GetById(id_account);

            if(arr[1] == account.thoi_gian_login_gmail)
            {
                if(time < DateTime.Now && DateTime.Now < time.AddMinutes(5))
                {
                    new ACCOUNTRepository().UpdateThoiGianLoginGmail(id_account, null);
                    USERModel user = SaveLoginInfo(id_account);
                    if (user.ma_role == "admin")
                        return RedirectToAction("Index", "PageAdmin");
                    if (user.ma_role == "employee")
                        return RedirectToAction("Index", "PageUser");
                }
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }


        public USERModel SaveLoginInfo(int id_account)
        {
            ACCOUNTModel account = new ACCOUNTModel();
            account.id = id_account;
            USERModel user = new USERRepository().GetUSERByIdAccount(account);

            //rememberMe: tự nhớ ho_ten_nguoi_dung của lần trước để tự động đăng nhập hay không?
            bool rememberMe = false;
            var authTicket = new FormsAuthenticationTicket(
                            1,                             // version
                            $"{user.ma_nguoi_dung}_{user.ho_ten_nguoi_dung}",// user name
                            DateTime.Now,                  // created
                            DateTime.Now.AddMinutes(480),   // expires
                            rememberMe,                    // persistent?
                            user.ma_role,                  // can be used to store roles
                            "/"
                            );

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);
            return user;
        }
        
    }
}