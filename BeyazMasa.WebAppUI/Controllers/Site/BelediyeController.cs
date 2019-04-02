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
    public class BelediyeController : Controller
    {

        IDuyurularService _duyurularService = new DuyurularManager(new EfDuyurularDal());
        IBelediyeYoneticilerService _belediyeYoneticilerService = new BelediyeYoneticilerManager(new EfBelediyeYoneticilerDal());
        IBasvurularService _basvurularService = new BasvurularManager(new EfBasvurularDal());
        IVatandaslarService _vatandaslarService = new VatandaslarManager(new EfVatandaslarDal());
        IBirimlerService _birimlerService = new BirimlerManager(new EfBirimlerDal());

        public ActionResult Index()
        {
            int belediyeId = Convert.ToInt32(Session["BelediyeId"]);
            ViewBag.BasvuruSayisi = _basvurularService.GetBasvuruByBelediye(belediyeId).Count;
            ViewBag.VatandasSayisi = _vatandaslarService.GetAllVatandasByBelediye(belediyeId).Count;
            ViewBag.BirimSayisi = _birimlerService.GetBirimByBelediye(belediyeId).Count;
            ViewBag.DuyuruSayisi = _duyurularService.GetAllDuyurular().Count;
            return View(_duyurularService.GetLastFiveDuyurular());
        }

        public ActionResult Duyurular()
        {
            return View(_duyurularService.GetAllDuyurular());
        }

        public ActionResult DuyuruDetay(int id)
        {
            return View(_duyurularService.GetById(id));
        }

        public ActionResult TeknikDestek()
        {
            return View();
        }

        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(BelediyeYoneticiler belediyeYonetici)
        {
            if (ModelState.IsValid)
            {
                var user = _belediyeYoneticilerService.Login(belediyeYonetici);
                if (user != null)
                {
                    Session["BelediyeId"] = user.BelediyeId;
                    return RedirectToAction("Index");
                }
            }
            return View(belediyeYonetici);
        }

        public ActionResult Cikis()
        {
            Session.Abandon();
            return RedirectToAction("Giris");
        }

    }
}