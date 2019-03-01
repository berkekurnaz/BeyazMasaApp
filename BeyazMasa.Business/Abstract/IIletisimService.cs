using BeyazMasa.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.Business.Abstract
{
    public interface IIletisimService
    {
        List<Iletisim> GetAllIletisim();
        void Add(Iletisim iletisim);
        void Delete(Iletisim iletisim);
        void Update(Iletisim iletisim);
        Iletisim GetById(int id);
    }
}
