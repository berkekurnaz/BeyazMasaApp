using BeyazMasa.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.Entity.Concrete
{
    public class Belediyeler : IEntity
    {
        public int Id { get; set; }
        public string BelediyeAd { get; set; }
        public string BelediyeAciklama { get; set; }
        public string BelediyeSehir { get; set; }
    }
}
