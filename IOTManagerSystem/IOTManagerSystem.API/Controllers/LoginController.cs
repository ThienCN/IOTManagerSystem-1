using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IOTManagerSystem.Model.USER;
using IOTManagerSystem.Repository.USER;
using IOTManagerSystem.Repository;
using System.Net.Mail;
using System.Web.Security;
using Google.Authenticator;

namespace IOTManagerSystem.API.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [Route("CheckLogin")]
        [HttpPost]
        public USERModel CheckLogin([FromBody] USERModel user)
        {
            USERModel result = new USERRepository().CheckLogin(user);
            return result;
        }

        [Route("SendAuthenticationSMS")]
        [HttpPost]
        public bool SendAuthenticationSMS([FromBody] USERModel user)
        {
            USERModel temp = new USERRepository().GetByEmail(user.email);

            //Xác thực bằng số điện thoại
            return AUTHENTICATIONRepository.SendVerifySMS(temp.sdt, "84");
        }

        [Route("CheckAuthenticationLoginSMS")]
        [HttpPost] 
        public bool CheckAuthenticationLoginSMS([FromBody] USERModel user)
        {
            USERModel temp = new USERRepository().GetByEmail(user.email);
            //Xác thực bằng số điện thoại
            return AUTHENTICATIONRepository.VerifySMSCode(temp.sdt, "84", user.ma_code_xac_thuc); ;
        }

        [Route("SendAuthenticationGmail")]
        [HttpPost]
        public bool SendAuthenticationGmail([FromBody] USERModel user)
        { 
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpC = new SmtpClient("smtp.gmail.com");
                //From address to send email
                mail.From = new MailAddress("hoangthikimphung0709@gmail.com");

                //To address to send email
                mail.To.Add(user.email);
                string thoi_gian_login_gmail = DateTime.Now.ToString("ddMMyyyyHHmmss");
                var hash = $"{user.email}_{thoi_gian_login_gmail}";
                hash = System.Web.HttpUtility.UrlEncode(EncryptTo.Encrypt(hash));
                string href = "http://localhost:50542/Login/CheckAuthenticationGmail?check=" + hash;
                mail.Body = "<b>Vui lòng truy cập vào địa chỉ để xác thực đăng nhập:</b>  <a href='" + href + "' >" + hash + "</a>";
                mail.IsBodyHtml = true;
                mail.Subject = "Đăng nhập Hệ thống quản lý thiết bị IOT";
                smtpC.Port = 587;

                //Credentials for From address
                smtpC.Credentials = new NetworkCredential("hoangthikimphung0709@gmail.com", "0070091994");
                smtpC.EnableSsl = true;
                smtpC.Send(mail);

                //Lưu vào DB
                new USERRepository().UpdateThoiGianLoginGmail(user.email, thoi_gian_login_gmail);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [Route("SendAuthenticationGG")]
        [HttpPost]
        public string SendAuthenticationGG([FromBody] USERModel user)
        {
            USERModel temp = new USERRepository().GetByEmail(user.email);
            //Two Factor Authentication Setup
            TwoFactorAuthenticator TwoFacAuth = new TwoFactorAuthenticator();
            string UserUniqueKey = (temp.ma_nguoi_dung + "HoangPhung");

            var setupInfo = TwoFacAuth.GenerateSetupCode("IOT Manager System", temp.ma_nguoi_dung, UserUniqueKey, 200, 200);
            return setupInfo.QrCodeSetupImageUrl;
        }

        [Route("CheckAuthenticationLoginGG")]
        [HttpPost]
        public bool CheckAuthenticationLoginGG([FromBody] USERModel user)
        {
            USERModel temp = new USERRepository().GetByEmail(user.email);
            TwoFactorAuthenticator TwoFacAuth = new TwoFactorAuthenticator();
            string UserUniqueKey = (temp.ma_nguoi_dung + "HoangPhung");
            bool isValid = TwoFacAuth.ValidateTwoFactorPIN(UserUniqueKey, user.ma_code_xac_thuc);
            return isValid;
        }
    }
}
