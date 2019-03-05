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
    public class SistemBelediyelerController : Controller
    {

        IBelediyelerService _belediyelerService = new BelediyelerManager(new EfBelediyelerDal());

        public ActionResult Index()
        {
            return View(_belediyelerService.GetAll());
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Belediyeler belediye)
        {
            if (ModelState.IsValid)
            {
                _belediyelerService.Add(belediye);
                return RedirectToAction("Index");
            }
            return View(belediye);
        }

        public ActionResult Guncelle(int id)
        {
            return View(_belediyelerService.GetById(id));
        }

        [HttpPost]
        public ActionResult Guncelle(int id, Belediyeler belediye)
        {
            if (ModelState.IsValid)
            {
                _belediyelerService.Update(belediye);
                return RedirectToAction("Index");
            }
            return View(belediye);
        }

        public ActionResult Sil(int id)
        {
            return View(_belediyelerService.GetById(id));
        }

        [HttpPost]
        public ActionResult Sil(int id, Belediyeler belediye, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                _belediyelerService.Delete(belediye);
                return RedirectToAction("Index");
            }
            return View(belediye);
        }

    }
}