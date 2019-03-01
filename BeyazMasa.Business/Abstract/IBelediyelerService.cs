using BeyazMasa.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.Business.Abstract
{
    public interface IBelediyelerService
    {
        List<Belediyeler> GetAll();
        void Add(Belediyeler belediye);
        void Delete(Belediyeler belediye);
        void Update(Belediyeler belediye);
        Belediyeler GetById(int id);
    }
}
