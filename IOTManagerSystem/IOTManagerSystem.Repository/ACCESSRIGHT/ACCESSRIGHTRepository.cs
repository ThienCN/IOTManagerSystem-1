using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOTManagerSystem.Repository.Core;
using IOTManagerSystem.Model.ACCESSRIGHT;

namespace IOTManagerSystem.Repository.ACCESSRIGHT
{
    public class ACCESSRIGHTRepository : BaseRepository, IACCESSRIGHTRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ACCESSRIGHTModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ACCESSRIGHTModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ACCESSRIGHTModel GetByMaNV(string ma_nhan_vien, string man_hinh)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("ma_nhan_vien", ma_nhan_vien);
            param.Add("man_hinh", man_hinh);

            IEnumerable<ACCESSRIGHTModel> temp = Query<ACCESSRIGHTModel>(@"SELECT xem, sua, them, xoa 
                                                                            FROM dbo.ACCESSRIGHT 
                                                                            WHERE ma_nhan_vien = @ma_nhan_vien AND man_hinh = @man_hinh", System.Data.CommandType.Text, param);
            if (temp != null && temp.Count() > 0)
                return temp.First();
            return null;
        }

        public bool Insert(ACCESSRIGHTModel model)
        {
            throw new NotImplementedException();
        }

        public bool Update(ACCESSRIGHTModel model)
        {
            throw new NotImplementedException();
        }
    }
}
