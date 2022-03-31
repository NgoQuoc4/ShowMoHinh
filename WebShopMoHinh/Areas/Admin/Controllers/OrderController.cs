using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopMoHinh.Models;
using System.Data.Entity;
namespace WebShopMoHinh.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public OnlineShopMoHinhEntities2 db = new OnlineShopMoHinhEntities2();
        public ActionResult Index()
        {
            if (Session["admin"] == null)
                return RedirectToAction("Index", "AdminLogin");
            var model = db.Orderproes.ToList();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            ViewBag.od = db.Orderproes.Find(id);
            var models = db.chitietDatHangs.Where(p => p.OrderID == id);
            return View(models);
        }
        public ActionResult Edit(int id)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Index", "AdminLogin");
            var model = db.Orderproes.Find(id);
            model.nvID = (int)Session["admin"];
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Orderpro orderpro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderpro).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Order");
        }
    }
}