using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopMoHinh.Models;
using System.Data.Entity;
namespace WebShopMoHinh.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public OnlineShopMoHinhEntities2 db = new OnlineShopMoHinhEntities2();
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            //var models = db.SanPhams.ToList();
            ViewBag.SanPhams = db.SanPhams.ToList();
            return View("Index");
        }
        public ActionResult Create()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            ViewBag.types = new SelectList(db.LoaiSanPhams.ToList(), "lspID", "lspName");
            ViewBag.manus = new SelectList(db.NhaSanXuats.ToList(), "nhasanxuatID", "nhasanxuatName");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SanPham sanPham, HttpPostedFileBase Images)
        {
            if (Images != null && Images.ContentLength > 0)
            {
                sanPham.Images = Images.FileName;
                string urlImages = Server.MapPath("~/Content/image/" + sanPham.Images);
                Images.SaveAs(urlImages);
            }
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.listNation = new SelectList(db.LoaiSanPhams, "lspID", "lspName", sanPham.lspID);
            ViewBag.listTypes = new SelectList(db.NhaSanXuats, "nhasanxuatID", "nhasanxuatName", sanPham.nhasanxuatID);

            return View(sanPham);
        }
        public ActionResult Edit(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            var models = db.SanPhams.Find(id);
            ViewBag.types = new SelectList(db.LoaiSanPhams.ToList(), "lspID", "lspName", models.lspID);
            ViewBag.manus = new SelectList(db.NhaSanXuats.ToList(), "nhasanxuatID", "nhasanxuatName", models.nhasanxuatID);
            return View(models);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SanPham sanpham, HttpPostedFileBase newimage)
        {
            if (newimage != null && newimage.ContentLength > 0)
            {
                sanpham.Images = newimage.FileName;
                string urlImage = Server.MapPath("~/Content/image/" + sanpham.Images);
                newimage.SaveAs(urlImage);
            }
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            ViewBag.types = new SelectList(db.LoaiSanPhams.ToList(), "lspID", "lspName", sanpham.lspID);
            ViewBag.manus = new SelectList(db.NhaSanXuats.ToList(), "nhasanxuatID", "nhasanxuatName", sanpham.nhasanxuatID);
            return View(sanpham);
        }
        public ActionResult Delete(int id)
        {
            SanPham sp = new SanPham();
            sp.spID = id;
            sp = db.SanPhams.Find(id);
            db.SanPhams.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var model = db.SanPhams.Find(id);
            return View(model);
        }

        public ActionResult timKiemSanPham(string tenSP)
        {
            ViewBag.loaiSP = db.LoaiSanPhams.OrderBy(sp => sp.lspID);
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            if (!string.IsNullOrEmpty(tenSP))
            {
                var query = from sp in db.SanPhams where sp.spName.Contains(tenSP) || sp.LoaiSanPham.lspName.Contains(tenSP) select sp;
                if (query.Count() == 0)
                {
                    return RedirectToAction("thongBaoRong", "ThemXoaSua");
                }
                return View(query);
            }
            return View();
        }



    }
}