using BeyazMasa.Business.Abstract;
using BeyazMasa.Business.Concrete;
using BeyazMasa.DataAccess.Concrete.EntityFramework;
using BeyazMasa.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BeyazMasa.WebAppUI.Controllers.Api
{
    public class ABelediyelerController : ApiController
    {

        IBelediyelerService _belediyelerService = new BelediyelerManager(new EfBelediyelerDal());

        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<Belediyeler> query = _belediyelerService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, query);
        }

        [HttpPost]
        public HttpResponseMessage Post(Belediyeler belediye)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _belediyelerService.Add(belediye);
                    HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Created, belediye);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + belediye.Id);
                    return message;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Veri ekleme işlemi yapılamadı.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, Belediyeler belediye)
        {
            try
            {
                Belediyeler bel = _belediyelerService.GetById(id);

                if (bel == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Belediye Id : " + belediye.Id);
                }
                else
                {
                    bel.BelediyeAd = belediye.BelediyeAd;
                    bel.BelediyeAciklama = belediye.BelediyeAciklama;
                    bel.BelediyeSehir = bel.BelediyeSehir;
                    return Request.CreateResponse(HttpStatusCode.OK, belediye);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id, Belediyeler belediye)
        {
            try
            {
                Belediyeler bel = _belediyelerService.GetById(id);

                if (bel == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Belediye Id : " + belediye.Id);
                }
                else
                {
                    _belediyelerService.Delete(belediye);
                    return Request.CreateResponse(HttpStatusCode.OK, "Belediye id : " + id);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
