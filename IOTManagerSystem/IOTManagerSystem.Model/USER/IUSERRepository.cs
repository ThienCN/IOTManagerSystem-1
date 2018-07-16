using IOTManagerSystem.Model.ACCOUNT;
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
        USERModel GetUSERByIdAccount(ACCOUNTModel account);
    }
}
