using BeyazMasa.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.Entity.Concrete
{
    public class Birimler : IEntity
    {
        public int Id { get; set; }
        public string BirimAd { get; set; }
        public string BirimAciklama { get; set; }
        public int BelediyeId { get; set; }
    }
}
