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
    public class BelediyeBirimYoneticilerController : Controller
    {

        IBirimYoneticilerService _birimYoneticilerService = new BirimYoneticilerManager(new EfBirimYoneticilerDal());
        IBirimlerService _birimlerService = new BirimlerManager(new EfBirimlerDal());

        public ActionResult Index()
        {
            int belediyeId = Convert.ToInt32(Session["BelediyeId"]);
            return View(_birimYoneticilerService.GetBirimYoneticiByBelediye(belediyeId));
        }

        public ActionResult Ekle()
        {
            int belediyeId = Convert.ToInt32(Session["BelediyeId"]);
            ViewBag.BirimlerId = new SelectList(_birimlerService.GetBirimByBelediye(belediyeId), "Id", "BirimAd");
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(BirimYoneticiler birimYonetici, string BirimlerId)
        {
            if (ModelState.IsValid)
            {
                birimYonetici.BirimId = Convert.ToInt32(BirimlerId);
                birimYonetici.BelediyeId = Convert.ToInt32(Session["BelediyeId"]);
                _birimYoneticilerService.Add(birimYonetici);
                return RedirectToAction("Index");
            }
            return View(birimYonetici);
        }

        public ActionResult Guncelle(int id)
        {
            int belediyeId = Convert.ToInt32(Session["BelediyeId"]);
            ViewBag.BirimlerId = new SelectList(_birimlerService.GetBirimByBelediye(belediyeId), "Id", "BirimAd");
            return View(_birimYoneticilerService.GetById(id));
        }

        [HttpPost]
        public ActionResult Guncelle(int id, BirimYoneticiler birimYonetici, string BirimlerId)
        {
            if (ModelState.IsValid)
            {
                birimYonetici.BirimId = Convert.ToInt32(BirimlerId);
                birimYonetici.BelediyeId = Convert.ToInt32(Session["BelediyeId"]);
                _birimYoneticilerService.Update(birimYonetici);
                return RedirectToAction("Index");
            }
            return View(birimYonetici);
        }

        public ActionResult Sil(int id)
        {
            return View(_birimYoneticilerService.GetById(id));
        }

        [HttpPost]
        public ActionResult Sil(int id, BirimYoneticiler birimYonetici, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                _birimYoneticilerService.Delete(birimYonetici);
                return RedirectToAction("Index");
            }
            return View(birimYonetici);
        }

    }
}