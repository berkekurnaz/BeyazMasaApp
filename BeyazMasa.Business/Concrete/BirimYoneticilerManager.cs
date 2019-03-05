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
    public class BirimYoneticilerManager : IBirimYoneticilerService
    {

        private IBirimYoneticilerDal _birimYoneticilerDal;

        public BirimYoneticilerManager(IBirimYoneticilerDal birimYoneticilerDal)
        {
            _birimYoneticilerDal = birimYoneticilerDal;
        }



        /* Yeni Bir Birim Yoneticisi Ekleme */
        public void Add(BirimYoneticiler birimYonetici)
        {
            _birimYoneticilerDal.Add(birimYonetici);
        }

        /* Bir Birim Yoneticisi Silme */
        public void Delete(BirimYoneticiler birimYonetici)
        {
            _birimYoneticilerDal.Delete(birimYonetici);
        }

        /* Belediyedeki Butun Birim Yoneticilerini Listeleme */
        public List<BirimYoneticiler> GetBirimYoneticiByBelediye(int belediyeId)
        {
            return _birimYoneticilerDal.GetAll(x => x.BelediyeId == belediyeId).ToList();
        }

        /* Belediyedeki Bir Birimdeki Butun Yoneticileri Listeleme */
        public List<BirimYoneticiler> GetBirimYoneticiByBelediye(int belediyeId, int birimId)
        {
            return _birimYoneticilerDal.GetAll(x => x.BelediyeId == belediyeId && x.BirimId == birimId );
        }

        /* Id Degerine Göre Birim Yoneticisi Bulma */
        public BirimYoneticiler GetById(int id)
        {
            return _birimYoneticilerDal.Get(x => x.Id == id);
        }

        /* Bir Birim Yoneticisi Guncelleme */
        public void Update(BirimYoneticiler birimYonetici)
        {
            _birimYoneticilerDal.Update(birimYonetici);
        }
    }
}
