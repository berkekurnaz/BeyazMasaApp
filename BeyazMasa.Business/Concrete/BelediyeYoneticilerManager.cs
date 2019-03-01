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
    public class BelediyeYoneticilerManager : IBelediyeYoneticilerService
    {
        private IBelediyeYoneticilerDal _belediyeYoneticilerDal;

        public BelediyeYoneticilerManager(IBelediyeYoneticilerDal belediyeYoneticilerDal)
        {
            _belediyeYoneticilerDal = belediyeYoneticilerDal;
        }



        /* Yeni Bir Belediye Yoneticisi Ekleme */
        public void Add(BelediyeYoneticiler belediyeYonetici)
        {
            _belediyeYoneticilerDal.Add(belediyeYonetici);
        }

        /* Bir Belediye Yoneticisi Silme */
        public void Delete(BelediyeYoneticiler belediyeYonetici)
        {
            _belediyeYoneticilerDal.Delete(belediyeYonetici);
        }

        /* Belediyeye Ait Yoneticileri Listeleme */
        public List<BelediyeYoneticiler> GetBelediyeYoneticiByBelediye(int belediyeId)
        {
            return _belediyeYoneticilerDal.GetAll(x => x.BelediyeId == belediyeId);
        }

        /* Id Degerine Göre Belediye Yoneticisi Bulma */
        public BelediyeYoneticiler GetById(int id)
        {
            return _belediyeYoneticilerDal.Get(x => x.Id == id);
        }

        /* Bir Belediye Yoneticisi Guncelleme */
        public void Update(BelediyeYoneticiler belediyeYonetici)
        {
            _belediyeYoneticilerDal.Update(belediyeYonetici);
        }
    }
}
