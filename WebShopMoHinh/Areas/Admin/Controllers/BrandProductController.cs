using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopMoHinh.Models;
using System.Data.Entity;
namespace WebShopMoHinh.Areas.Admin.Controllers
{
    public class BrandProductController : Controller
    {
        // GET: Admin/BrandProduct
        public OnlineShopMoHinhEntities2 db = new OnlineShopMoHinhEntities2();
        // GET: Admin/TypeProduct
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            var models = db.NhaSanXuats.ToList();
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
        public ActionResult Create(NhaSanXuat nhaSanXuat)
        {
            if (ModelState.IsValid)
            {
                db.NhaSanXuats.Add(nhaSanXuat);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "BrandProduct");
        }
        public ActionResult Details(string id)
        {
            var model = db.NhaSanXuats.Find(id);
            return View(model);
        }
        public ActionResult Delete(string id)
        {
            var model = db.NhaSanXuats.Find(id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            var item = db.NhaSanXuats.Find(id);
            db.NhaSanXuats.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index", "BrandProduct");
        }
        public ActionResult Edit(string id)
        {
            var model = db.NhaSanXuats.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(NhaSanXuat nhaSanXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaSanXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "BrandProduct");
            }
            return View(nhaSanXuat);
        }
    }
}