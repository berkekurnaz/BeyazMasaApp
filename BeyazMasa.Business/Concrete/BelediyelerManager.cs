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
    public class BelediyelerManager : IBelediyelerService
    {
        private IBelediyelerDal _belediyelerDal;

        public BelediyelerManager(IBelediyelerDal belediyelerDal)
        {
            _belediyelerDal = belediyelerDal;
        }


        /* Yeni Bir Belediye Ekleme */
        public void Add(Belediyeler belediye)
        {
            _belediyelerDal.Add(belediye);
        }

        /* Bir Belediye Silme */
        public void Delete(Belediyeler belediye)
        {
            _belediyelerDal.Delete(belediye);
        }

        /* Butun Belediyeleri Listeleme */
        public List<Belediyeler> GetAll()
        {
            return _belediyelerDal.GetAll();
        }

        /* Id Degerine Göre Belediye Bulma */
        public Belediyeler GetById(int id)
        {
            return _belediyelerDal.Get(x => x.Id == id);
        }

        /* Bir Belediye Guncelleme */
        public void Update(Belediyeler belediye)
        {
            _belediyelerDal.Update(belediye);
        }
    }
}
