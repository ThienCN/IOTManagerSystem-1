using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOTManagerSystem.Repository.Core;
using IOTManagerSystem.Model.PARAMETER;

namespace IOTManagerSystem.Repository.PARAMETER
{
    public class PARAMETERRepository : BaseRepository, IPARAMETERRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PARAMETERModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PARAMETERModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PARAMETERModel> GetListGioiTinh()
        {
            return Query<PARAMETERModel>(@"SELECT id, ten_tham_so, gia_tri_tham_so, loai_tham_so
                                                FROM dbo.PARAMETER
                                                WHERE loai_tham_so = 'GIOITINH'", System.Data.CommandType.Text);
        }

        public bool Insert(PARAMETERModel model)
        {
            throw new NotImplementedException();
        }

        public bool Update(PARAMETERModel model)
        {
            throw new NotImplementedException();
        }
    }
}
