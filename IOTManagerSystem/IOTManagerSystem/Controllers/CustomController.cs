using IOTManagerSystem.API;
using IOTManagerSystem.Model.USER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IOTManagerSystem.Controllers
{
    public class CustomController : Controller
    {
        protected USERModel loginedUser;
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            loginedUser = new USERModel();
            try
            {
                var temp = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                if (temp.Contains('_'))
                {
                    loginedUser.ma_nguoi_dung = EncryptTo.Encrypt(temp.Split('_')[0]);
                    loginedUser.ho_ten_nguoi_dung = temp.Split('_')[1];
                }
                else
                    loginedUser = null;
            }
            catch (Exception)
            {
                loginedUser = null;
            }
            
        }
    }
}