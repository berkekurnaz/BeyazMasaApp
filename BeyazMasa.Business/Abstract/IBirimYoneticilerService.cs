using BeyazMasa.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.Business.Abstract
{
    public interface IBirimYoneticilerService
    {
        List<BirimYoneticiler> GetBirimYoneticiByBelediye(int belediyeId); // Belediyeye Ait Olan Butun Birim Yoneticilerini Listeleme.
        List<BirimYoneticiler> GetBirimYoneticiByBelediye(int belediyeId,int birimId); // Belediyeye Ve Birime Ait Olan Birim Yoneticilerini Listeleme.
        void Add(BirimYoneticiler birimYonetici);
        void Delete(BirimYoneticiler birimYonetici);
        void Update(BirimYoneticiler birimYonetici);
        BirimYoneticiler GetById(int id);
    }
}
