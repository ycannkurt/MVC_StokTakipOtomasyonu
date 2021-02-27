using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakipOtomasyonu.Models.Entity;

namespace MVC_StokTakipOtomasyonu.Controllers
{
    public class CategoriesController : Controller
    {
        MVC_StokTakipEntities1 db = new MVC_StokTakipEntities1();
        public ActionResult Products()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Brands()
        {

            return View();
        }



        public ActionResult Index()
        {

            return View(db.Kategoriler.ToList());

        }

        public ActionResult NewCategory()
        {
            return View();
        }

        public ActionResult NewCategoryAction(Kategoriler p)
        {
            db.Kategoriler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult GetUpdateInfo(Kategoriler p)
        {
            var model = db.Kategoriler.Find(p.ID);
            if (model == null) return HttpNotFound();
            return View(model);
        }

        public ActionResult Update(Kategoriler p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDeleteInfo(Kategoriler p)
        {
            var model = db.Kategoriler.Find(p.ID);
            if (model == null) return HttpNotFound();
            return View(model);
        }
    }
}