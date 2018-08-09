using IOTManagerSystem.Model.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTManagerSystem.Model.USER
{
    public interface IUSERRepository:IRepository<USERModel>
    {
        USERModel CheckLogin(USERModel user);
        void UpdateThoiGianLoginGmail(string ma_nguoi_dung, string thoi_gian_login_gmail);

        USERModel GetByEmail(string email);
        USERModel GetByMaUser(string ma_nguoi_dung);
    }
}
