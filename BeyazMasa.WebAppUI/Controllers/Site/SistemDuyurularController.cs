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
    public class SistemDuyurularController : Controller
    {

        IDuyurularService _duyurularService = new DuyurularManager(new EfDuyurularDal());

        public ActionResult Index()
        {
            return View(_duyurularService.GetAllDuyurular());
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Duyurular duyuru)
        {
            if (ModelState.IsValid)
            {
                _duyurularService.Add(duyuru);
                return RedirectToAction("Index");
            }
            return View(duyuru);
        }

        public ActionResult Guncelle(int id)
        {
            return View(_duyurularService.GetById(id));
        }

        [HttpPost]
        public ActionResult Guncelle(int id, Duyurular duyuru)
        {
            if (ModelState.IsValid)
            {
                _duyurularService.Update(duyuru);
                return RedirectToAction("Index");
            }
            return View(duyuru);
        }

        public ActionResult Sil(int id)
        {
            return View(_duyurularService.GetById(id));
        }

        [HttpPost]
        public ActionResult Sil(int id, Duyurular duyuru, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                _duyurularService.Delete(duyuru);
                return RedirectToAction("Index");
            }
            return View(duyuru);
        }

    }
}