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
    public class BirimYoneticilerController : Controller
    {

        IBirimYoneticilerService _birimYoneticilerService = new BirimYoneticilerManager(new EfBirimYoneticilerDal());

        public ActionResult Index()
        {
            int birimId = Convert.ToInt32(Session["BirimId"]);
            int birimBelediyeId = Convert.ToInt32(Session["BirimBelediyeId"]);
            return View(_birimYoneticilerService.GetBirimYoneticiByBelediye(birimBelediyeId));
        }

        public ActionResult Incele(int id)
        {
            return View(_birimYoneticilerService.GetById(id));
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(BirimYoneticiler birimYonetici)
        {
            if (ModelState.IsValid)
            {
                birimYonetici.BirimId = Convert.ToInt32(Session["BirimId"]);
                birimYonetici.BelediyeId = Convert.ToInt32(Session["BirimBelediyeId"]);
                _birimYoneticilerService.Add(birimYonetici);
                return RedirectToAction("Index");
            }
            return View(birimYonetici);
        }

        public ActionResult Guncelle(int id)
        {
            return View(_birimYoneticilerService.GetById(id));
        }

        [HttpPost]
        public ActionResult Guncelle(int id, BirimYoneticiler birimYonetici)
        {
            if (ModelState.IsValid)
            {
                birimYonetici.BirimId = Convert.ToInt32(Session["BirimId"]);
                birimYonetici.BelediyeId = Convert.ToInt32(Session["BirimBelediyeId"]);
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