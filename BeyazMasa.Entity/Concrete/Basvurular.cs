using BeyazMasa.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.Entity.Concrete
{
    public class Basvurular : IEntity
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string Dosya { get; set; }
        public string Tarih { get; set; }
        public string Durum { get; set; }
        public int VatandasId { get; set; }
        public int BirimId { get; set; }
        public int BelediyeId { get; set; }
    }
}
