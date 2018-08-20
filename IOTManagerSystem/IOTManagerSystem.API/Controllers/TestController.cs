using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IOTManagerSystem.Model.TEST;
using IOTManagerSystem.Repository.TEST;


namespace IOTManagerSystem.API.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [Route("getallnull")]
        [HttpGet]
        public IEnumerable<ProvinceMe> GetAllNull()
        {
            IEnumerable<ProvinceMe> result = new ProvinceRootRes().GetAll();
            return result;
        }
    }
}
