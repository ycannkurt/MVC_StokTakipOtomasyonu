using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakipOtomasyonu.Models.Entity;

namespace MVC_StokTakipOtomasyonu.Controllers
{
    public class UnitsController : Controller
    {
        MVC_StokTakipEntities1 db = new MVC_StokTakipEntities1();

        public ActionResult Index()
        {
            return View(db.Birimler.ToList());
        }

        public ActionResult NewUnit()
        {
            return View();
        }
      
        public ActionResult NewUnitAction(Birimler p)
        {
            if (p.ID==0)
            {
                db.Birimler.Add(p);
            }
            else
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            }
            
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetUpdateInfo(Birimler p)
        {
            var model = db.Birimler.Find(p.ID);
            if (model == null) return HttpNotFound();
            return View("NewUnit",model);
        }

        public ActionResult Update(Birimler p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}