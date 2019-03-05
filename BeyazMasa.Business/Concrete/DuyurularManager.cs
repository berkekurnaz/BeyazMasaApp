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
    public class DuyurularManager : IDuyurularService
    {

        private IDuyurularDal _duyurularDal;

        public DuyurularManager(IDuyurularDal duyurularDal)
        {
            _duyurularDal = duyurularDal;
        }



        /* Yeni Bir Duyuru Ekleme */
        public void Add(Duyurular duyuru)
        {
            _duyurularDal.Add(duyuru);
        }

        /* Bir Duyuruyu Silme */
        public void Delete(Duyurular duyuru)
        {
            _duyurularDal.Delete(duyuru);
        }

        /* Butun Duyurulari Listeleme */
        public List<Duyurular> GetAllDuyurular()
        {
            return _duyurularDal.GetAll();
        }

        /* Id Degerine Göre Duyuru Bulma */
        public Duyurular GetById(int id)
        {
            return _duyurularDal.Get(x => x.Id == id);
        }

        /* Bir Duyuruyu Guncelleme */
        public void Update(Duyurular duyuru)
        {
            _duyurularDal.Update(duyuru);
        }

    }
}
