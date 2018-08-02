using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTManagerSystem.Model.ACCOUNT
{
    public class ACCOUNTModel
    {
        public int id { get; set; }
        public string ten_tai_khoan { get; set; }
        public string mat_khau { get; set; }
        public int id_loai_xac_thuc { get; set; }
        public int tinh_trang { get; set; }
        public int id_ma_nguoi_dung { get; set; }
        public string ma_code_xac_thuc { get; set; }
        public string thoi_gian_login_gmail { get; set; }
    }
}
