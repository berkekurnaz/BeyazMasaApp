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
    public class BasvurularManager : IBasvurularService
    {

        private IBasvurularDal _basvurularDal;

        public BasvurularManager(IBasvurularDal basvurularDal)
        {
            _basvurularDal = basvurularDal;
        }



        /* Yeni Bir Basvuru Ekleme */
        public void Add(Basvurular basvuru)
        {
            _basvurularDal.Add(basvuru);
        }

        /* Bir Basvuru Silme */
        public void Delete(Basvurular basvuru)
        {
            _basvurularDal.Delete(basvuru);
        }

        /* Belediyeye Ait Butun Basvurulari Listeleme */
        public List<Basvurular> GetBasvuruByBelediye(int belediyeId)
        {
            return _basvurularDal.GetAll(x => x.BelediyeId == belediyeId);
        }

        /* Birime Ait Butun Basvurulari Listeleme */
        public List<Basvurular> GetBasvuruByBirim(int birimId)
        {
            return _basvurularDal.GetAll(x => x.BirimId == birimId);
        }

        /* Id Degerine Göre Basvuru Bulma */
        public Basvurular GetById(int id)
        {
            return _basvurularDal.Get(x => x.Id == id);
        }

        /* Id Degerine Göre Basvurunun Durumunu Guncelleme */
        public void UpdateDurum(int basvuruId, string durum)
        {
            Basvurular basvuru = _basvurularDal.Get(x => x.Id == basvuruId);
            basvuru.Durum = durum;
            _basvurularDal.Update(basvuru);
        }
    }
}
