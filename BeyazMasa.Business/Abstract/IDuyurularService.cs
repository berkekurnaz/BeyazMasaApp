using BeyazMasa.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.Business.Abstract
{
    public interface IDuyurularService
    {
        List<Duyurular> GetAllDuyurular();
        List<Duyurular> GetLastFiveDuyurular();
        void Add(Duyurular duyuru);
        void Delete(Duyurular duyuru);
        void Update(Duyurular duyuru);
        Duyurular GetById(int id);
    }
}
