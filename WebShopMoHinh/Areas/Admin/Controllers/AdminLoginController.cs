using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopMoHinh.Models;
using System.Data.Entity;
namespace WebShopMoHinh.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Admin/AdminLogin
        public OnlineShopMoHinhEntities2 db = new OnlineShopMoHinhEntities2();
        // GET: Admin/AdminLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            string pass = endCode.enCodeMD5(password);
            var result = db.NhanViens.Where(s => s.username.Equals(username) && s.password.Equals(pass)).FirstOrDefault();
            if (result != null)
            {
                Session["admin"] = result.nvID;
                return RedirectToAction("Index", "AdminHome");
            }
            else
            {
                return View();
            }
        }
    }
}