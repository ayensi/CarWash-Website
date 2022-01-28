using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using otoyikama.Models.Data;
using otoyikama.Models.Model;

namespace otoyikama.Controllers
{
    public class HizmetController : Controller
    {
        private EntityDbContext db = new EntityDbContext();

        // GET: Hizmet
        public ActionResult Index()
        {
            return View(db.Hizmet.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string name,int price)
        {
            Hizmet hizmet = new Hizmet();
            hizmet.hizmetisim = name;
            hizmet.fiyat = price;
            db.Hizmet.Add(hizmet);
            db.SaveChanges();
            TempData["Success"] = "Hizmet başarıyla eklendi...";
            return RedirectToAction("Index", "Hizmet");
        }

    
        public ActionResult Delete(int id)
        {

            var h = db.Hizmet.Find(id);
            db.Hizmet.Remove(h);
            db.SaveChanges();
            TempData["Success"] = "Hizmet başarıyla silindi...";
            return RedirectToAction("Index");
        }
    }
}
