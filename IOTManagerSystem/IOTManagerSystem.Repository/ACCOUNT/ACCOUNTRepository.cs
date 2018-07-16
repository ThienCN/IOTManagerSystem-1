using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOTManagerSystem.Model.ACCOUNT;
using IOTManagerSystem.Repository.Core;
using IOTManagerSystem.Model.USER;

namespace IOTManagerSystem.Repository.ACCOUNT
{
    public class ACCOUNTRepository : BaseRepository, IACCOUNTRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ACCOUNTModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ACCOUNTModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ACCOUNTModel model)
        {
            throw new NotImplementedException();
        }

        public bool Update(ACCOUNTModel model)
        {
            throw new NotImplementedException();
        }

        public ACCOUNTModel CheckLogin(ACCOUNTModel account)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("ten_tai_khoan", account.ten_tai_khoan);
            param.Add("mat_khau", account.mat_khau);

            IEnumerable<ACCOUNTModel> temp = Query<ACCOUNTModel>(@"SELECT DISTINCT id_loai_xac_thuc, id
                                                            FROM dbo.ACCOUNT
                                                            WHERE ten_tai_khoan=@ten_tai_khoan AND mat_khau=@mat_khau",
                                                                    CommandType.Text, param);
            if (temp.Count() > 0)
                return temp.First();
            return null;
        }

        
    }
}
