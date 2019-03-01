using BeyazMasa.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.Business.Abstract
{
    public interface IVatandaslarService
    {
        List<Vatandaslar> GetAllVatandasByBelediye(int belediyeId); // Belediyeye Ait Vatandaslari Listeleme.
        void Add(Vatandaslar vatandas);
        void Delete(Vatandaslar vatandas);
        void Update(Vatandaslar vatandas);
        Vatandaslar GetById(int id);
    }
}
