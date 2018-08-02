using IOTManagerSystem.Model.Core.Interfaces;
using IOTManagerSystem.Model.USER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTManagerSystem.Model.ACCOUNT
{
    public interface IACCOUNTRepository: IRepository<ACCOUNTModel>
    {
        ACCOUNTModel CheckLogin(ACCOUNTModel account);
        void UpdateThoiGianLoginGmail(int id, string dateTime);
    }
}
