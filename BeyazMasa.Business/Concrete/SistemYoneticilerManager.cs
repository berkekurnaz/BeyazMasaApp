using BeyazMasa.Business.Abstract;
using BeyazMasa.DataAccess.Abstract;
using BeyazMasa.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.Business.Concrete
{
    public class SistemYoneticilerManager : ISistemYoneticilerService
    {

        private ISistemYoneticilerDal _sistemYoneticilerDal;

        public SistemYoneticilerManager(ISistemYoneticilerDal sistemYoneticilerDal)
        {
            _sistemYoneticilerDal = sistemYoneticilerDal;
        }



        /* Yeni Bir Sistem Yoneticisi Ekleme */
        public void Add(SistemYoneticiler sistemYonetici)
        {
            _sistemYoneticilerDal.Add(sistemYonetici);
        }

        /* Bir Sistem Yoneticisi Silme */
        public void Delete(SistemYoneticiler sistemYonetici)
        {
            _sistemYoneticilerDal.Delete(sistemYonetici);
        }

        /* Butun Sistem Yoneticilerini Listeleme */
        public List<SistemYoneticiler> GetAllSistemYoneticiler()
        {
            return _sistemYoneticilerDal.GetAll();
        }

        /* Id Degerine Göre Sistem Yoneticisi Bulma */
        public SistemYoneticiler GetById(int id)
        {
            return _sistemYoneticilerDal.Get(x => x.Id == id);
        }

        /* Sistem Yoneticisinin Sisteme Giris Yapmasi */
        public SistemYoneticiler Login(SistemYoneticiler sistemYonetici)
        {
            var result = new SistemYoneticiler();
            result = _sistemYoneticilerDal.Get(x => x.KullaniciAdi == sistemYonetici.KullaniciAdi && x.Sifre == sistemYonetici.Sifre);
            return result;
        }

        /* Bir Sistem Yoneticisi Guncelleme */
        public void Update(SistemYoneticiler sistemYonetici)
        {
            _sistemYoneticilerDal.Update(sistemYonetici);
        }
    }
}
