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
    public class SistemController : Controller
    {

        IBirimlerService _birimlerService = new BirimlerManager(new EfBirimlerDal());
        IBelediyelerService _belediyelerService = new BelediyelerManager(new EfBelediyelerDal());
        IDuyurularService _duyurularService = new DuyurularManager(new EfDuyurularDal());
        IIletisimService _iletisimService = new IletisimManager(new EfIletisimDal());
        ISistemYoneticilerService _sistemYoneticilerService = new SistemYoneticilerManager(new EfSistemYoneticilerDal());

        public ActionResult Index()
        {
            ViewBag.BelediyeSayisi = _belediyelerService.GetAll().Count;
            ViewBag.BirimSayisi = _birimlerService.GetAllBirimler().Count;
            ViewBag.DuyuruSayisi = _duyurularService.GetAllDuyurular().Count;
            ViewBag.IletisimSayisi = _iletisimService.GetAllIletisim().Count;
            return View();
        }

        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(SistemYoneticiler sistemYonetici)
        {
            if (ModelState.IsValid)
            {
                var user = _sistemYoneticilerService.Login(sistemYonetici);
                if (user != null)
                {
                    Session["SistemId"] = user.Id;
                    return RedirectToAction("Index");
                }
            }
            return View(sistemYonetici);
        }

        public ActionResult Cikis()
        {
            Session.Abandon();
            return RedirectToAction("Giris");
        }

    }
}