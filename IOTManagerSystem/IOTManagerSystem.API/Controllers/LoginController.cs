using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IOTManagerSystem.Model.ACCOUNT;
using IOTManagerSystem.Model.USER;
using IOTManagerSystem.Repository.ACCOUNT;
using IOTManagerSystem.Repository.USER;
using IOTManagerSystem.Repository;
using System.Net.Mail;
using System.Web.Security;

namespace IOTManagerSystem.API.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [Route("CheckLogin")]
        [HttpPost]
        public ACCOUNTModel CheckLogin([FromBody] ACCOUNTModel account)
        {
            ACCOUNTModel result = new ACCOUNTRepository().CheckLogin(account);

            return result;
        }

        [Route("SendAuthenticationSMS")]
        [HttpPost]
        public bool SendAuthenticationSMS([FromBody] ACCOUNTModel account)
        {
            USERModel user = new USERRepository().GetUSERByIdAccount(account);

            //Xác thực bằng số điện thoại
            return AUTHENTICATIONRepository.SendVerifySMS(user.sdt, "84");
        }

        [Route("CheckAuthenticationLoginSMS")]
        [HttpPost] 
        public bool CheckAuthenticationLoginSMS([FromBody] ACCOUNTModel account)
        {
            USERModel user = new USERRepository().GetUSERByIdAccount(account);
            //Xác thực bằng số điện thoại
            return AUTHENTICATIONRepository.VerifySMSCode(user.sdt, "84", account.ma_code_xac_thuc); ;
        }

        [Route("SendAuthenticationGmail")]
        [HttpPost]
        public bool SendAuthenticationGmail([FromBody] ACCOUNTModel account)
        { 
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpC = new SmtpClient("smtp.gmail.com");
                //From address to send email
                mail.From = new MailAddress("hoangthikimphung0709@gmail.com");

                //To address to send email
                mail.To.Add("15110283@student.hcmute.edu.vn");
                string thoi_gian_login_gmail = DateTime.Now.ToString("ddMMyyyyHHmmss");
                var hash = $"{account.id}_{thoi_gian_login_gmail}";
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
                new ACCOUNTRepository().UpdateThoiGianLoginGmail(account.id, thoi_gian_login_gmail);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
