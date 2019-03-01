using BeyazMasa.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.Business.Abstract
{
    public interface ISistemYoneticilerService
    {
        List<SistemYoneticiler> GetAllSistemYoneticiler();
        void Add(SistemYoneticiler sistemYonetici);
        void Delete(SistemYoneticiler sistemYonetici);
        void Update(SistemYoneticiler sistemYonetici);
        SistemYoneticiler GetById(int id);
    }
}
