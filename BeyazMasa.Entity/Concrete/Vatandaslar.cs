using BeyazMasa.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.Entity.Concrete
{
    public class Vatandaslar : IEntity
    {
        public int Id { get; set; }
        public string VatandasIsim { get; set; }
        public string VatandasSoyad { get; set; }
        public string VatandasTc { get; set; }
        public string VatandasKullaniciAdi { get; set; }
        public string VatandasSifre { get; set; }
        public int VatandasBelediyeId { get; set; }
    }
}
