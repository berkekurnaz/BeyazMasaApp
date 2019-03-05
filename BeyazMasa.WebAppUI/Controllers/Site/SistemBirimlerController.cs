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
    public class SistemBirimlerController : Controller
    {

        IBirimlerService _birimlerService = new BirimlerManager(new EfBirimlerDal());
        IBelediyelerService _belediyelerService = new BelediyelerManager(new EfBelediyelerDal());

        public ActionResult Index()
        {
            return View(_birimlerService.GetAllBirimler());
        }

        public ActionResult Ekle()
        {
            ViewBag.BelediyeId = new SelectList(_belediyelerService.GetAll(), "Id", "BelediyeAd");
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Birimler birim)
        {
            if (ModelState.IsValid)
            {
                _birimlerService.Add(birim);
                return RedirectToAction("Index");
            }
            return View(birim);
        }

        public ActionResult Guncelle(int id)
        {
            ViewBag.BelediyeId = new SelectList(_belediyelerService.GetAll(), "Id", "BelediyeAd");
            return View(_birimlerService.GetById(id));
        }

        [HttpPost]
        public ActionResult Guncelle(int id, Birimler birim)
        {
            if (ModelState.IsValid)
            {
                _birimlerService.Update(birim);
                return RedirectToAction("Index");
            }
            return View(birim);
        }

        public ActionResult Sil(int id)
        {
            ViewBag.BelediyeId = new SelectList(_belediyelerService.GetAll(), "Id", "BelediyeAd");
            return View(_birimlerService.GetById(id));
        }

        [HttpPost]
        public ActionResult Sil(int id, Birimler birim, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                _birimlerService.Delete(birim);
                return RedirectToAction("Index");
            }
            return View(birim);
        }

    }
}