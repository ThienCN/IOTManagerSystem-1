using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTManagerSystem.Model
{
    public class ResponseModel
    {
        public string carrier { get; set; }
        public bool is_cellphone { get; set; }
        public string message { get; set; }
        public int seconds_to_expire { get; set; }
        public string uuid { get; set; }
        public bool success { get; set; }
        public string error_code { get; set; }
        public ErrorModel errors { get; set; }
    }
}
