using IOTManagerSystem.Repository.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOTManagerSystem.Model.TEST;


namespace IOTManagerSystem.Repository.TEST
{
    public class ProvinceRootRes: BaseRepository
    {
        public IEnumerable<ProvinceMe> GetAll()
        {
            return Query<ProvinceMe>(@"SELECT ten_tinh_thanh_pho
                                            FROM dbo.CRM_City
                                            WHERE ProvinceCode IS NULL", CommandType.Text);
        }
    }
}
