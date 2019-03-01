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
using System.Data.Entity;

namespace BeyazMasa.WebAppUI.Controllers.Api
{
    public class ABasvurularController : ApiController
    {

        IBasvurularService _basvurularService = new BasvurularManager(new EfBasvurularDal());

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            List<Basvurular> query = _basvurularService.GetBasvuruByBelediye(id);
            return Request.CreateResponse(HttpStatusCode.OK, query);
        }

        [HttpPost]
        public HttpResponseMessage Post(Basvurular basvuru)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _basvurularService.Add(basvuru);
                    HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Created, basvuru);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + basvuru.Id);
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
        public HttpResponseMessage Put(int id, Basvurular basvuru)
        {
            try
            {
                Basvurular bas = _basvurularService.GetById(id);

                if (bas == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Basvuru Id : " + basvuru.Id);
                }
                else
                {
                    bas.Baslik = basvuru.Baslik;
                    bas.Icerik = basvuru.Icerik;
                    bas.Dosya = basvuru.Dosya;
                    bas.Tarih = basvuru.Tarih;
                    bas.Durum = basvuru.Durum;
                    bas.VatandasId = basvuru.VatandasId;
                    bas.BirimId = basvuru.BirimId;
                    bas.BelediyeId = basvuru.BelediyeId;
                    return Request.CreateResponse(HttpStatusCode.OK, basvuru);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id, Basvurular basvuru)
        {
            try
            {
                Basvurular bas = _basvurularService.GetById(id);

                if (bas == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Basvuru Id : " + basvuru.Id);
                }
                else
                {
                    _basvurularService.Delete(basvuru);
                    return Request.CreateResponse(HttpStatusCode.OK, "Basvuru Id : " + id);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
