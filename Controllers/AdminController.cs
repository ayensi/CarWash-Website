using otoyikama.Models.Data;
using otoyikama.Models.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace otoyikama.Controllers
{
    public class AdminController : Controller
    {
        private EntityDbContext db = new EntityDbContext();
        // GET: Admin
        public ActionResult Index()
        {
       
            return View();
        }
        [HttpGet]
        public ActionResult NewClient()
        {
            ViewModel hizmetModel = new ViewModel();

            hizmetModel.hizmet = db.Hizmet.ToList<Hizmet>();

            return View(hizmetModel);
        }
        [HttpPost]
        public ActionResult NewClient(string name, string lastname, string telephone, string plate, int[] myParams)
        {

            Musteri musteri = new Musteri();
            if (db.Musteri != null)
            {
                if (!db.Musteri.Where(x => x.plaka == plate).Any())
                {
                    musteri.isim = name;
                    musteri.soyisim = lastname;
                    musteri.telefon = telephone;
                    musteri.plaka = plate;
                    db.Musteri.Add(musteri);
                    db.SaveChanges();
                }
            }
            else
            {
                musteri.isim = name;
                musteri.soyisim = lastname;
                musteri.telefon = telephone;
                musteri.plaka = plate;
                db.Musteri.Add(musteri);
                db.SaveChanges();
            }
            if(db.Islem.Where(x=>x.plaka == plate && x.onay==false).Any())
            {
                TempData["Error"] = "Bu araç zaten sistemde kayıtlı...";
                return RedirectToAction("CurrentClients", "Admin");
            }
            Islem islem = new Islem();
            islem.Musteri = new Musteri();
            IslemHizmet islemhizmet = new IslemHizmet();
            islem.giristarihi = DateTime.Now;
            islem.plaka = plate;
            islem.Musteri.isim = name;
            islem.Musteri.soyisim = lastname;
            islem.Musteri.telefon = telephone;
            islem.Musteri.plaka = plate;
           
            db.Islem.Add(islem);
            db.SaveChanges();
            var onprocessplate = db.Islem.Where(x => x.plaka == plate & x.onay == false).FirstOrDefault();
            List<Hizmet> allServices = db.Hizmet.ToList();
            List<Hizmet> selectedServices = new List<Hizmet>();
            foreach (var item in myParams)
            {
                foreach (var nesne in allServices)
                {
                    if (item == nesne.hizmet_id)
                    {
                        selectedServices.Add(nesne);
                    }
                }
            }
            int toplamfiyat = 0;
            foreach (var item in selectedServices)
            {
                toplamfiyat += item.fiyat;
                islemhizmet.islem_id = onprocessplate.islem_id;
                islemhizmet.hizmet_id = item.hizmet_id;
                db.IslemHizmet.Add(islemhizmet);
                db.SaveChanges();
                islemhizmet = new IslemHizmet();
            }
            islem.toplamfiyat = toplamfiyat;
            db.SaveChanges();
            TempData["Success"] = "Müşteri başarıyla eklendi...";
            
            return RedirectToAction("CurrentClients", "Admin");
        }
        [HttpGet]
        public ActionResult CurrentClients()
        {
            
            ViewModel nesne = new ViewModel();
            nesne.musteri = db.Musteri.ToList();
            nesne.hizmet = db.Hizmet.ToList();
            nesne.islem = db.Islem.ToList();
            nesne.islemhizmet = db.IslemHizmet.ToList();
            return View(nesne);
        }
        [HttpPost]
        public ActionResult CurrentClients(int islemid)
        {
            if(db.Islem.Where(x=>x.islem_id == islemid).Any())
            {
                var currentClient = db.Islem.Where(x => x.islem_id == islemid).FirstOrDefault();
                currentClient.onay = true;
                currentClient.cikistarihi = DateTime.Now;
                db.SaveChanges();
             
                TempData["Success"] = "İşlem başarıyla tamamlandı...";

                //SMS GÖNDER


                return RedirectToAction("AllClients", "Admin");
            }
            else
            {
                TempData["Error"] = "İşlem başarısız...";
                return RedirectToAction("Index","Admin");
            }
            
        }
        [HttpGet]
        public ActionResult AllClients()
        {
            ViewModel model = new ViewModel();
            model.musteri = db.Musteri.ToList();
            model.hizmet = db.Hizmet.ToList();
            model.islemhizmet = db.IslemHizmet.ToList();
            model.islem = db.Islem.Where(x=>x.onay == true).ToList();
            return View(model);
        }
        
    }
}