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
    public class BirimDuyurularController : Controller
    {

        IDuyurularService _duyurularService = new DuyurularManager(new EfDuyurularDal());

        public ActionResult Index()
        {
            return View(_duyurularService.GetAllDuyurular());
        }

        public ActionResult Incele(int id)
        {
            var duyuru = _duyurularService.GetById(id);
            if (duyuru == null)
            {
                return HttpNotFound();
            }
            return View(duyuru);
        }

    }
}