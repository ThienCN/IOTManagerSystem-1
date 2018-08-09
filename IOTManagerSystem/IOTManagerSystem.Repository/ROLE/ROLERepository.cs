using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOTManagerSystem.Model.ROLE;
using IOTManagerSystem.Repository.Core;

namespace IOTManagerSystem.Repository.ROLE
{
    public class ROLERepository : BaseRepository, IROLERepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ROLEModel> GetAll()
        {
            return Query<ROLEModel>(@"SELECT id, ma_role, ten_role FROM dbo.ROLE", CommandType.Text);
        }

        public ROLEModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ROLEModel model)
        {
            throw new NotImplementedException();
        }

        public bool Update(ROLEModel model)
        {
            throw new NotImplementedException();
        }
    }
}
