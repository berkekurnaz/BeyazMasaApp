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
    public class BelediyeVatandaslarController : Controller
    {

        IVatandaslarService _vatandaslarService = new VatandaslarManager(new EfVatandaslarDal());

        public ActionResult Index()
        {
            int belediyeId = Convert.ToInt32(Session["BelediyeId"]);
            return View(_vatandaslarService.GetAllVatandasByBelediye(belediyeId));
        }

        public ActionResult Incele(int id)
        {
            return View(_vatandaslarService.GetById(id));
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Vatandaslar vatandas)
        {
            if (ModelState.IsValid)
            {
                vatandas.VatandasBelediyeId = Convert.ToInt32(Session["BelediyeId"]);
                _vatandaslarService.Add(vatandas);
                return RedirectToAction("Index");
            }
            return View(vatandas);
        }

        public ActionResult Guncelle(int id)
        {
            return View(_vatandaslarService.GetById(id));
        }

        [HttpPost]
        public ActionResult Guncelle(int id, Vatandaslar vatandas)
        {
            if (ModelState.IsValid)
            {
                vatandas.VatandasBelediyeId = Convert.ToInt32(Session["BelediyeId"]);
                _vatandaslarService.Update(vatandas);
                return RedirectToAction("Index");
            }
            return View(vatandas);
        }

        public ActionResult Sil(int id)
        {
            return View(_vatandaslarService.GetById(id));
        }

        [HttpPost]
        public ActionResult Sil(int id, Vatandaslar vatandas, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                _vatandaslarService.Delete(vatandas);
                return RedirectToAction("Index");
            }
            return View(vatandas);
        }

    }
}