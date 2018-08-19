using IOTManagerSystem.Repository.USER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IOTManagerSystem.API;
using IOTManagerSystem.Model.USER;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Globalization;
using IOTManagerSystem.Repository.ROLE;

namespace IOTManagerSystem.Controllers
{
    [Authorize(Roles = "user")]
    public class PageUserController : CustomController
    {
        // GET: PageUser
        public ActionResult Index()
        {
            if (loginedUser == null)
                return View("Login");

            ViewBag.MaUser = loginedUser.ma_nguoi_dung;
            ViewBag.NameUser = loginedUser.ho_ten_nguoi_dung;

            ViewBag.InfoUser = new USERRepository().GetByMaUser(EncryptTo.Decrypt(loginedUser.ma_nguoi_dung));
            return View("PageUser");
        }

        [HttpPost]
        public ActionResult UpdateProfile(USERModel user)
        {
            USERModel exist = new USERRepository().GetByMaUser(EncryptTo.Decrypt(user.ma_nguoi_dung));
            var file = Request.Files["avartar"];
            if (file != null)
            {
                //string FileToDelete = Server.MapPath(exist.avartar);
                //System.IO.File.Delete(FileToDelete);
                string destinationPath = Helpers.Upload.UploadFile(file);
                user.avartar = destinationPath;

            }
            else
            {
                user.avartar = exist.avartar;
            }

            user.ma_nguoi_dung = EncryptTo.Decrypt(user.ma_nguoi_dung);
            if (new USERRepository().Update(user))
            {
                ViewBag.InfoUser = user;
                return Json(new { success = true });
            }
            else return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult UpdatePassword(string ma_nguoi_dung, string mat_khau_hien_tai, string mat_khau_moi, string mat_khau_moi_repeat)
        {
            USERModel exist = new USERRepository().GetByMaUser(EncryptTo.Decrypt(ma_nguoi_dung));
            if (String.Compare(mat_khau_hien_tai, EncryptTo.Decrypt(exist.mat_khau), false) == 0) // 2 chuỗi giống nhau có phân biệt hoa thường
            {
                if (String.Compare(mat_khau_moi, mat_khau_moi_repeat, false) == 0)
                {
                    if (new USERRepository().UpdatePassword(EncryptTo.Decrypt(ma_nguoi_dung), EncryptTo.Encrypt(mat_khau_moi)))
                        return Json(new { success = true });
                    else return Json(new { success = false, error = "Cập nhật mật khẩu không thành công" });
                }
                else return Json(new { success = false, error = "Nhập lại chính xác mật khẩu mới" });
            }
            else return Json(new { success = false, error = "Mật khẩu hiện tại không chính xác" });

            //if (mat_khau_hien_tai == exist.mat_khau) // 2 chuỗi giống nhau có phân biệt hoa thường
            //{
            //    if (mat_khau_moi == mat_khau_moi_repeat)
            //    {
            //        if (new USERRepository().UpdatePassword(EncryptTo.Decrypt(ma_nguoi_dung), mat_khau_moi))
            //            return Json(new { success = true });
            //        else return Json(new { success = false, error = "Cập nhật mật khẩu không thành công" });
            //    }
            //    else return Json(new { success = false, error = "Nhập lại chính xác mật khẩu mới" });
            //}
            //else return Json(new { success = false, error = "Mật khẩu hiện tại không chính xác" });
        }
    }
}