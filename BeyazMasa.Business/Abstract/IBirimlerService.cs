using BeyazMasa.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.Business.Abstract
{
    public interface IBirimlerService
    {
        List<Birimler> GetBirimByBelediye(int belediyeId); // Belediyeye Ait Olan Birimleri Listeleme.
        void Add(Birimler birim, int belediyeId);
        void Delete(Birimler birim);
        void Update(Birimler birim);
        Birimler GetById(int id);
    }
}
