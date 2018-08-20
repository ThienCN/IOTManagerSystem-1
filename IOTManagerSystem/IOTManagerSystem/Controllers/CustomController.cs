using IOTManagerSystem.API;
using IOTManagerSystem.Model.USER;
using IOTManagerSystem.Model.ACCESSRIGHT;
using IOTManagerSystem.Repository.ACCESSRIGHT;
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
        protected ACCESSRIGHTModel accessRight = new ACCESSRIGHTModel() { xem = false, them = false, sua = false, xoa = false, xuat = false, nhap = false };
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            loginedUser = new USERModel();
            try
            {
                //var temp = FormsAuthentication.Decrypt(Request.Cookies["SMARTPARK"].Value).Name;
                var temp = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                if (temp.Contains('_'))
                {
                    loginedUser.ma_nguoi_dung = EncryptTo.Encrypt(temp.Split('_')[0]);
                    loginedUser.ho_ten_nguoi_dung = temp.Split('_')[1];
                    var man_hinh = this.GetType().Name.Substring(0, this.GetType().Name.IndexOf("Controller"));
                    ACCESSRIGHTModel temp2 = new ACCESSRIGHTRepository().GetByMaNV(temp.Split('_')[0], man_hinh);
                    if (temp2 != null)
                        accessRight = temp2;
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