using BeyazMasa.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.Business.Abstract
{
    public interface IBasvurularService
    {
        List<Basvurular> GetBasvuruByBelediye(int belediyeId); // Belediyeye Ait Olan Başvuruları Listeleme.
        void Add(Basvurular basvuru);
        void Delete(Basvurular basvuru);
        Basvurular GetById(int id);
    }
}
