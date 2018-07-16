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

        [Route("AuthenticationLogin")]
        [HttpPost]
        public bool AuthenticationLogin([FromBody] ACCOUNTModel account)
        {
            USERModel user = new USERRepository().GetUSERByIdAccount(account);

            //Xác thực bằng số điện thoại
            if(account.id_loai_xac_thuc == 1)
                return AUTHENTICATIONRepository.SendVerifySMS(user.sdt, "84");

            return false;

        }

        [Route("CheckAuthenticationLogin")]
        [HttpPost] 
        public bool CheckAuthenticationLogin([FromBody] ACCOUNTModel account)
        {
            USERModel user = new USERRepository().GetUSERByIdAccount(account);
            bool flag = false;
            //Xác thực bằng số điện thoại
            if (account.id_loai_xac_thuc == 1)
                flag = AUTHENTICATIONRepository.VerifySMSCode(user.sdt, "84", account.ma_code_xac_thuc);

            return flag;
        }

        

    }
}
