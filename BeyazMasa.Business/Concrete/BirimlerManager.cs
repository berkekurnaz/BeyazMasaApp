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
    public class BirimlerManager : IBirimlerService
    {
        private IBirimlerDal _birimlerDal;

        public BirimlerManager(IBirimlerDal birimlerDal)
        {
            _birimlerDal = birimlerDal;
        }



        /* Yeni Bir Birim Ekleme */
        public void Add(Birimler birim, int belediyeId)
        {
            birim.BelediyeId = belediyeId;
            _birimlerDal.Add(birim);
        }

        /* Bir Birim Silme */
        public void Delete(Birimler birim)
        {
            _birimlerDal.Delete(birim);
        }

        /* Belediyeye Ait Butun Birimleri Listeleme */
        public List<Birimler> GetBirimByBelediye(int belediyeId)
        {
            return _birimlerDal.GetAll(x => x.BelediyeId == belediyeId);
        }

        /* Id Degerine Göre Birim Bulma */
        public Birimler GetById(int id)
        {
            return _birimlerDal.Get(x => x.Id == id);
        }

        /* Bir Birim Guncelleme */
        public void Update(Birimler birim)
        {
            _birimlerDal.Update(birim);
        }
    }
}
