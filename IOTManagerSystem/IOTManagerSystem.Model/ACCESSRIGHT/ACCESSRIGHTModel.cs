using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTManagerSystem.Model.ACCESSRIGHT
{
    public class ACCESSRIGHTModel
    {
        public int id { get; set; }
        public string ma_nhan_vien { get; set; }
        public string man_hinh { get; set; }
        public bool xem { get; set; }
        public bool sua { get; set; }
        public bool them { get; set; }
        public bool xoa { get; set; }
        public bool xuat { get; set; }
        public bool nhap { get; set; }
    }
}
