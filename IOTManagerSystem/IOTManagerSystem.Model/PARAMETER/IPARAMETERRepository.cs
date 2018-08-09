using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOTManagerSystem.Model.Core.Interfaces;

namespace IOTManagerSystem.Model.PARAMETER
{
    public interface IPARAMETERRepository:IRepository<PARAMETERModel>
    {
        IEnumerable<PARAMETERModel> GetListGioiTinh();
    }
}
