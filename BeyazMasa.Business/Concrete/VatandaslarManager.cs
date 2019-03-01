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
    public class VatandaslarManager : IVatandaslarService
    {

        private IVatandaslarDal _vatandaslarDal;

        public VatandaslarManager(IVatandaslarDal vatandaslarDal)
        {
            _vatandaslarDal = vatandaslarDal;
        }



        /* Yeni Bir Vatandas Ekleme */
        public void Add(Vatandaslar vatandas)
        {
            _vatandaslarDal.Add(vatandas);
        }

        /* Bir Vatandasi Silme */
        public void Delete(Vatandaslar vatandas)
        {
            _vatandaslarDal.Delete(vatandas);
        }

        /* Belediyeye Ait Vatandaslari Listeleme */
        public List<Vatandaslar> GetAllVatandasByBelediye(int belediyeId)
        {
            return _vatandaslarDal.GetAll(x => x.VatandasBelediyeId == belediyeId);
        }

        /* Id Degerine Göre Vatandas Bulma */
        public Vatandaslar GetById(int id)
        {
            return _vatandaslarDal.Get(x => x.Id == id);
        }

        /* Bir Vatandasi Guncelleme */
        public void Update(Vatandaslar vatandas)
        {
            _vatandaslarDal.Update(vatandas);
        }

    }
}
