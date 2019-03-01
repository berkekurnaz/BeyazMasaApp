using BeyazMasa.DataAccess.Abstract;
using BeyazMasa.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyazMasa.DataAccess.Concrete.EntityFramework
{
    public class EfBirimlerDal : EfEntityRepositoryBase<Birimler, DatabaseContext>, IBirimlerDal
    {

    }
}
