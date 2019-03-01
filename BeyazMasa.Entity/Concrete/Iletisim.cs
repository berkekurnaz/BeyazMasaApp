using BeyazMasa.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.Entity.Concrete
{
    public class Iletisim : IEntity
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string Mesaj { get; set; }
        public string Icerik { get; set; }
        public string Tarih { get; set; }
    }
}
