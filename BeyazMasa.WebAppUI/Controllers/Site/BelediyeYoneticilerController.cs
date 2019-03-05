using BeyazMasa.Business.Abstract;
using BeyazMasa.Business.Concrete;
using BeyazMasa.DataAccess.Concrete.EntityFramework;
using BeyazMasa.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeyazMasa.WebAppUI.Controllers.Site
{
    public class BelediyeYoneticilerController : Controller
    {

        IBelediyeYoneticilerService _belediyeYoneticilerService = new BelediyeYoneticilerManager(new EfBelediyeYoneticilerDal());

        public ActionResult Index()
        {
            int belediyeId = Convert.ToInt32(Session["BelediyeId"]);
            return View(_belediyeYoneticilerService.GetBelediyeYoneticiByBelediye(belediyeId));
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(BelediyeYoneticiler belediyeYonetici)
        {
            if (ModelState.IsValid)
            {
                belediyeYonetici.BelediyeId = Convert.ToInt32(Session["BelediyeId"]);
                _belediyeYoneticilerService.Add(belediyeYonetici);
                return RedirectToAction("Index");
            }
            return View(belediyeYonetici);
        }

        public ActionResult Guncelle(int id)
        {
            return View(_belediyeYoneticilerService.GetById(id));
        }

        [HttpPost]
        public ActionResult Guncelle(int id, BelediyeYoneticiler belediyeYonetici)
        {
            if (ModelState.IsValid)
            {
                belediyeYonetici.BelediyeId = Convert.ToInt32(Session["BelediyeId"]);
                _belediyeYoneticilerService.Update(belediyeYonetici);
                return RedirectToAction("Index");
            }
            return View(belediyeYonetici);
        }

        public ActionResult Sil(int id)
        {
            return View(_belediyeYoneticilerService.GetById(id));
        }

        [HttpPost]
        public ActionResult Sil(int id, BelediyeYoneticiler belediyeYonetici, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                _belediyeYoneticilerService.Delete(belediyeYonetici);
                return RedirectToAction("Index");
            }
            return View(belediyeYonetici);
        }


    }
}