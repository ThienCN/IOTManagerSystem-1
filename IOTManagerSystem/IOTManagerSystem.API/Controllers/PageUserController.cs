using IOTManagerSystem.Model.USER;
using IOTManagerSystem.Repository.USER;
using IOTManagerSystem.Model.ACCOUNT;
using IOTManagerSystem.Repository.ACCOUNT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using IOTManagerSystem.API;

namespace IOTManagerSystem.API.Controllers
{
    [RoutePrefix("api/user")]
    public class PageUserController : ApiController
    {
        [Route("Profile")]
        [HttpPost]
        public USERModel GetProfile([FromBody] USERModel user)
        {
            return new USERRepository().GetByMaUser(EncryptTo.Decrypt(user.ma_nguoi_dung));
        }

        [Route("Account")]
        [HttpPost]
        public ACCOUNTModel GetAccount([FromBody] USERModel user)
        {
            return new ACCOUNTRepository().GetByMaUser(EncryptTo.Decrypt(user.ma_nguoi_dung));
        }
    }
}
