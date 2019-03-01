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
    public class IletisimManager : IIletisimService
    {

        private IIletisimDal _iletisimDal;

        public IletisimManager(IIletisimDal iletisimDal)
        {
            _iletisimDal = iletisimDal;
        }



        /* Yeni Bir Iletisim Mesaji Ekleme */
        public void Add(Iletisim iletisim)
        {
            _iletisimDal.Add(iletisim);
        }

        /* Bir Iletisim Mesaji Silme */
        public void Delete(Iletisim iletisim)
        {
            _iletisimDal.Delete(iletisim);
        }

        /* Butun Iletisim Mesajlarini Listeleme */
        public List<Iletisim> GetAllIletisim()
        {
            return _iletisimDal.GetAll();
        }

        /* Id Degerine Göre Iletisim Mesaji Bulma */
        public Iletisim GetById(int id)
        {
            return _iletisimDal.Get(x => x.Id == id);
        }

        /* Bir Iletisim Mesaji Guncelleme */
        public void Update(Iletisim iletisim)
        {
            _iletisimDal.Update(iletisim);
        }

    }
}
