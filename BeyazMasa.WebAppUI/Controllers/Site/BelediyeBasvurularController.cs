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
    public class BelediyeBasvurularController : Controller
    {

        IBasvurularService _basvurularService = new BasvurularManager(new EfBasvurularDal());
        IVatandaslarService _vatandaslarService = new VatandaslarManager(new EfVatandaslarDal());

        public ActionResult Index()
        {
            int belediyeId = Convert.ToInt32(Session["BelediyeId"]);  
            return View(_basvurularService.GetBasvuruByBelediye(belediyeId));
        }

        public ActionResult Incele(int id)
        {
            return View(_basvurularService.GetById(id));
        }

        public ActionResult Guncelle(int id)
        {
            return View(_basvurularService.GetById(id));
        }

        [HttpPost]
        public ActionResult Guncelle(int id, string basvurununDurumu)
        {
            if (ModelState.IsValid)
            {
                _basvurularService.UpdateDurum(id, basvurununDurumu);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Sil(int id)
        {
            return View(_basvurularService.GetById(id));
        }

        [HttpPost]
        public ActionResult Sil(int id, Basvurular basvuru, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                _basvurularService.Delete(basvuru);
                return RedirectToAction("Index");
            }
            return View(basvuru);
        }

    }
}