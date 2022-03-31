using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopMoHinh.Models;
using System.Data.Entity;
namespace WebShopMoHinh.Areas.Admin.Controllers
{
    public class StaffController : Controller
    {
        // GET: Admin/Staff
        public OnlineShopMoHinhEntities2 db = new OnlineShopMoHinhEntities2();
        // GET: Admin/Nation
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            var models = db.NhanViens.ToList();
            return View(models);
        }
        public ActionResult Create()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(NhanVien nhanViens)
        {
            if (ModelState.IsValid)
            {
                endCode md5 = new endCode();
                nhanViens.password = endCode.enCodeMD5(nhanViens.password);
                db.NhanViens.Add(nhanViens);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Staff");
        }
        public ActionResult Details(int id)
        {
            var model = db.NhanViens.Find(id);
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var model = db.NhanViens.Find(id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var item = db.NhanViens.Find(id);
            db.NhanViens.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index", "Staff");
        }
        public ActionResult Edit(int id)
        {
            var model = db.NhanViens.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(NhanVien nhanViens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanViens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Staff");
            }
            return View(nhanViens);
        }
    }
}