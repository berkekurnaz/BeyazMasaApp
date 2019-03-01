using BeyazMasa.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.Entity.Concrete
{
    public class BelediyeYoneticiler : IEntity
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public int BelediyeId { get; set; }
    }
}
