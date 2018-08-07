using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTManagerSystem.Model.USER
{
    public class USERModel
    {
        public int id { get; set; }
        public string ma_nguoi_dung { get; set; }
        public string ho_ten_nguoi_dung { get; set; }
        public string gioi_tinh { get; set; }
        public string sdt { get; set; }
        public string cmnd { get; set; }
        public string email { get; set; }
        public string dia_chi { get; set; }
        public string avartar { get; set; }
        public string ngay_sinh { get; set; }
        public string noi_sinh { get; set; }

        public int id_role { get; set; }
        public string ma_role { get; set; }
        public string ten_role { get; set; }

    }
}
