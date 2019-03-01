using BeyazMasa.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.Business.Abstract
{
    public interface IBelediyeYoneticilerService
    {
        List<BelediyeYoneticiler> GetBelediyeYoneticiByBelediye(int belediyeId); // Belediyeye Ait Olan Belediye Yoneticilerini Listeleme.
        void Add(BelediyeYoneticiler belediyeYonetici);
        void Delete(BelediyeYoneticiler belediyeYonetici);
        void Update(BelediyeYoneticiler belediyeYonetici);
        BelediyeYoneticiler GetById(int id);
    }
}
