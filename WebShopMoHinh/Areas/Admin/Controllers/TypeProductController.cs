﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopMoHinh.Models;
using System.Data.Entity;
namespace WebShopMoHinh.Areas.Admin.Controllers
{
    public class TypeProductController : Controller
    {
        // GET: Admin/TypeProduct
        public OnlineShopMoHinhEntities2 db = new OnlineShopMoHinhEntities2();
        // GET: Admin/TypeProduct
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            var models = db.LoaiSanPhams.ToList();
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
        public ActionResult Create(LoaiSanPham loaiSanPhams)
        {
            if (ModelState.IsValid)
            {
                db.LoaiSanPhams.Add(loaiSanPhams);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "TypeProduct");
        }
        public ActionResult Details(string id)
        {
            var model = db.LoaiSanPhams.Find(id);
            return View(model);
        }
        public ActionResult Delete(string id)
        {
            var model = db.LoaiSanPhams.Find(id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            var item = db.LoaiSanPhams.Find(id);
            db.LoaiSanPhams.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index", "TypeProduct");
        }
        public ActionResult Edit(string id)
        {
            var model = db.LoaiSanPhams.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(LoaiSanPham loaiSanPhams)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiSanPhams).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "TypeProduct");
            }
            return View(loaiSanPhams);
        }
    }
}