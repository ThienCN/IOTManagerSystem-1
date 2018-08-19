using IOTManagerSystem.Model.USER;
using IOTManagerSystem.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace IOTManagerSystem.Repository.USER
{
    public class USERRepository : BaseRepository, IUSERRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<USERModel> GetAll()
        {
            return Query<USERModel>(@"SELECT [USER].id, ma_nguoi_dung, ho_ten_nguoi_dung, p.gia_tri_tham_so AS gioi_tinh, sdt,
		                                    cmnd, email, dia_chi, avartar, ngay_sinh, noi_sinh, id_role, ten_role, p.ten_tham_so
                                    FROM [USER], dbo.ROLE, dbo.PARAMETER p
                                    WHERE id_role=ROLE.id AND gioi_tinh=p.ten_tham_so", CommandType.Text);
        }

        public USERModel GetById(int id)
        {
            //DynamicParameters param = new DynamicParameters();
            //param.Add("id", id);
            //param.Add("type", "getbyid");

            //return Query<USERModel>("spUSER", CommandType.StoredProcedure, param).First();
            throw new NotImplementedException();
        }

        public bool Insert(USERModel model)
        {
            throw new NotImplementedException();
        }

        public bool Update(USERModel model)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("ma_nguoi_dung", model.ma_nguoi_dung);
            param.Add("ho_ten_nguoi_dung", model.ho_ten_nguoi_dung);
            param.Add("gioi_tinh", model.gioi_tinh);
            param.Add("sdt", model.sdt);
            param.Add("cmnd", model.cmnd);
            param.Add("email", model.email);
            param.Add("dia_chi", model.dia_chi);
            param.Add("ngay_sinh", model.ngay_sinh);
            param.Add("noi_sinh", model.noi_sinh);
            param.Add("avartar", model.avartar);
            param.Add("type", "updateuser");

            return Execute<USERModel>("spUSER", CommandType.StoredProcedure, param);
        }

        public bool UpdatePassword(string ma_nguoi_dung, string mat_khau)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("ma_nguoi_dung", ma_nguoi_dung);
            param.Add("mat_khau", mat_khau);
            param.Add("type", "updatepassworduser");

            return Execute<USERModel>("spUSER", CommandType.StoredProcedure, param);
        }

        public USERModel GetByEmail(string email)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("email", email);
            param.Add("type", "getbyemail");

            IEnumerable<USERModel> list = Query<USERModel>("spUSER", CommandType.StoredProcedure, param);
            if (list != null && list.Count() > 0)
                return list.First();
            return null;
        }

        public USERModel CheckLogin(USERModel user)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("email", user.email);
            param.Add("mat_khau", user.mat_khau);

            IEnumerable<USERModel> temp = Query<USERModel>(@"SELECT DISTINCT id_loai_xac_thuc
                                                                FROM dbo.[USER]
                                                                WHERE email = @email AND mat_khau = @mat_khau AND tinh_trang=1", CommandType.Text, param);
            if (temp.Count() > 0)
                return temp.First();
            return null;
        }

        public void UpdateThoiGianLoginGmail(string email, string dateTime)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("email", email);
            param.Add("thoi_gian_login_gmail", dateTime);

            Query<USERModel>(@"UPDATE dbo.[USER]
                                SET thoi_gian_login_gmail = @thoi_gian_login_gmail
                                WHERE email = @email", CommandType.Text, param);
        }

        public USERModel GetByMaUser(string ma_nguoi_dung)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("ma_nguoi_dung", ma_nguoi_dung);
            param.Add("type", "getbymanguoidung");

            IEnumerable<USERModel> list = Query<USERModel>("spUSER", CommandType.StoredProcedure, param);
            if (list != null && list.Count() > 0)
                return list.First();
            return null;
        }
    }
}