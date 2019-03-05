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
    public class SistemIletisimController : Controller
    {

        IIletisimService _iletisimService = new IletisimManager(new EfIletisimDal());

        public ActionResult Index()
        {
            return View(_iletisimService.GetAllIletisim());
        }

        public ActionResult Guncelle(int id)
        {
            return View(_iletisimService.GetById(id));
        }

        [HttpPost]
        public ActionResult Guncelle(int id, Iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                _iletisimService.Update(iletisim);
                return RedirectToAction("Index");
            }
            return View(iletisim);
        }

        public ActionResult Sil(int id)
        {
            return View(_iletisimService.GetById(id));
        }

        [HttpPost]
        public ActionResult Sil(int id, Iletisim iletisim, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                _iletisimService.Delete(iletisim);
                return RedirectToAction("Index");
            }
            return View(iletisim);
        }

    }
}