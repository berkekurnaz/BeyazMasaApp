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
    public class SistemYoneticilerController : Controller
    {

        ISistemYoneticilerService _sistemYoneticilerService = new SistemYoneticilerManager(new EfSistemYoneticilerDal());

        public ActionResult Index()
        {
            return View(_sistemYoneticilerService.GetAllSistemYoneticiler());
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(SistemYoneticiler sistemYonetici)
        {
            if (ModelState.IsValid)
            {
                _sistemYoneticilerService.Add(sistemYonetici);
                return RedirectToAction("Index");
            }
            return View(sistemYonetici);
        }

        public ActionResult Guncelle(int id)
        {
            return View(_sistemYoneticilerService.GetById(id));
        }

        [HttpPost]
        public ActionResult Guncelle(int id, SistemYoneticiler sistemYonetici)
        {
            if (ModelState.IsValid)
            {
                _sistemYoneticilerService.Update(sistemYonetici);
                return RedirectToAction("Index");
            }
            return View(sistemYonetici);
        }

        public ActionResult Sil(int id)
        {
            return View(_sistemYoneticilerService.GetById(id));
        }

        [HttpPost]
        public ActionResult Sil(int id, SistemYoneticiler sistemYonetici, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                _sistemYoneticilerService.Delete(sistemYonetici);
                return RedirectToAction("Index");
            }
            return View(sistemYonetici);
        }

    }
}