using IOTManagerSystem.Model.USER;
using IOTManagerSystem.Repository.USER;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IOTManagerSystem.Repository.PARAMETER;
using IOTManagerSystem.Repository.ROLE;
using IOTManagerSystem.API;


namespace IOTManagerSystem.Controllers
{
    [Authorize(Roles = "admin, employee")]
    public class ManagerUserController : CustomController
    {
        // GET: ManagerUser
        public ActionResult Index()
        {
            if (loginedUser == null)
                return View("Login");

            ViewBag.MaUser = loginedUser.ma_nguoi_dung;
            ViewBag.NameUser = loginedUser.ho_ten_nguoi_dung;
            ViewBag.ListGioiTinh = new PARAMETERRepository().GetListGioiTinh();
            ViewBag.ListRole = new ROLERepository().GetAll();
            return View("ManagerUser");
        }

        public ActionResult ManagerUser()
        {
            if (loginedUser == null)
                return View("Login");

            if (accessRight.xem)
            {
                ViewBag.MaUser = loginedUser.ma_nguoi_dung;
                ViewBag.NameUser = loginedUser.ho_ten_nguoi_dung;
                ViewBag.ListGioiTinh = new PARAMETERRepository().GetListGioiTinh();
                ViewBag.ListRole = new ROLERepository().GetAll();
                return View("AdminManagerUser");
            }
            else
                return RedirectToAction("Index", "Error");


        }

        public ActionResult ReadUsers([DataSourceRequest]DataSourceRequest request)
        {
            IEnumerable<USERModel> list = new USERRepository().GetAllUsers();
            return Json(list.ToDataSourceResult(request));
        }

        public ActionResult CreateUpdateProfile(USERModel user)
        {
            if (user.ma_nguoi_dung == "0")
            {
                if (accessRight.them)
                {
                    var file = Request.Files["avartar"];
                    if (file != null)
                    {
                        string destinationPath = More.UploadFile.Upload("AvatarUser", file);
                        user.avartar = destinationPath;
                    }
                    else
                        user.avartar = "/Picture/doremon.png";
                    user.mat_khau = EncryptTo.Encrypt(user.cmnd);

                    bool flagInsert = new USERRepository().Insert(user);
                    if (flagInsert)
                        return Json(new { success = true });
                    return Json(new { success = false, error = "Email đã tồn tại!" });
                }
            }
            else if (accessRight.sua)
            {
                var file = Request.Files["avartar"];
                USERModel userRoot = new USERRepository().GetByMaUser(user.ma_nguoi_dung);
                user.mat_khau = userRoot.mat_khau;
                user.id_loai_xac_thuc = userRoot.id_loai_xac_thuc;
                user.tinh_trang = userRoot.tinh_trang;
                user.thoi_gian_login_gmail = userRoot.thoi_gian_login_gmail;
                if (file != null)
                {
                    if(userRoot.avartar != "/UploadFile/AvatarUser/doremon.png")
                    {
                        string FileToDelete = Server.MapPath(userRoot.avartar);
                        try
                        {
                            System.IO.File.Delete(FileToDelete);
                        }
                        catch { }
                    }
                    string destinationPath = More.UploadFile.Upload("AvatarUser", file);
                    user.avartar = destinationPath;
                }
                else
                    user.avartar = userRoot.avartar;
                bool flagUpdate = new USERRepository().Update(user);
                if (flagUpdate)
                    return Json(new { success = true });
                return Json(new { success = false, error = "Email đã tồn tại!" });
            }
            return Json(true);
        }
    }
}