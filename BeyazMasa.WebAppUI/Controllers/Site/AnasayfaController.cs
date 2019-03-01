using BeyazMasa.Business.Abstract;
using BeyazMasa.Business.Concrete;
using BeyazMasa.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeyazMasa.WebAppUI.Controllers.Site
{
    public class AnasayfaController : Controller
    {

        IBelediyelerService _belediyelerService = new BelediyelerManager(new EfBelediyelerDal());

        public ActionResult Index()
        {
            return View(_belediyelerService.GetAll());
        }

    }
}