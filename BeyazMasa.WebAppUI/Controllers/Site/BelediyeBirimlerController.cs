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
    public class BelediyeBirimlerController : Controller
    {

        IBirimlerService _birimlerService = new BirimlerManager(new EfBirimlerDal());

        public ActionResult Index()
        {
            int belediyeId = Convert.ToInt32(Session["BelediyeId"]);
            return View(_birimlerService.GetBirimByBelediye(belediyeId));
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Birimler birim)
        {
            if (ModelState.IsValid)
            {
                birim.BelediyeId = Convert.ToInt32(Session["BelediyeId"]);
                _birimlerService.Add(birim);
                return RedirectToAction("Index");
            }
            return View(birim);
        }

        public ActionResult Guncelle(int id)
        {
            return View(_birimlerService.GetById(id));
        }

        [HttpPost]
        public ActionResult Guncelle(int id, Birimler birim)
        {
            if (ModelState.IsValid)
            {
                birim.BelediyeId = Convert.ToInt32(Session["BelediyeId"]);
                _birimlerService.Update(birim);
                return RedirectToAction("Index");
            }
            return View(birim);
        }

        public ActionResult Sil(int id)
        {
            return View(_birimlerService.GetById(id));
        }

        [HttpPost]
        public ActionResult Sil(int id, Birimler birim, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                birim.BelediyeId = Convert.ToInt32(Session["BelediyeId"]);
                _birimlerService.Delete(birim);
                return RedirectToAction("Index");
            }
            return View(birim);
        }

    }
}