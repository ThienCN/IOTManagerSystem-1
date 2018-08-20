using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOTManagerSystem.Model.Core.Interfaces;

namespace IOTManagerSystem.Model.ACCESSRIGHT
{
    public interface IACCESSRIGHTRepository:IRepository<ACCESSRIGHTModel>
    {
        ACCESSRIGHTModel GetByMaNV(string ma_nhan_vien, string man_hinh);
    }
}
