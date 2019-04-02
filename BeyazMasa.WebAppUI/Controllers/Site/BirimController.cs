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
    public class BirimController : Controller
    {

        IBirimlerService _birimlerService = new BirimlerManager(new EfBirimlerDal());
        IBirimYoneticilerService _birimYoneticilerService = new BirimYoneticilerManager(new EfBirimYoneticilerDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(BirimYoneticiler birimYonetici)
        {
            if (ModelState.IsValid)
            {
                var user = _birimYoneticilerService.Login(birimYonetici);
                if (user != null)
                {
                    Session["BirimId"] = user.BirimId;
                    Session["BirimBelediyeId"] = user.BelediyeId;
                    return RedirectToAction("Index");
                }
            }
            return View(birimYonetici);
        }

    }
}