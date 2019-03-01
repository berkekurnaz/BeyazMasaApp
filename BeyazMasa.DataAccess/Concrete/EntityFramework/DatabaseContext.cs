using BeyazMasa.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.DataAccess.Concrete.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Basvurular> Basvurular { get; set; }
        public DbSet<Belediyeler> Belediyeler { get; set; }
        public DbSet<BelediyeYoneticiler> BelediyeYoneticiler { get; set; }
        public DbSet<Birimler> Birimler { get; set; }
        public DbSet<BirimYoneticiler> BirimYoneticiler { get; set; }
        public DbSet<Duyurular> Duyurular { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<SistemYoneticiler> SistemYoneticiler { get; set; }
        public DbSet<Vatandaslar> Vatandaslar { get; set; }
    }
}
