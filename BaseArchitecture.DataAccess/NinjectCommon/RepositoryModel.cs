using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BaseArchitecture.DataAccess.NinjectCommon
{
    public class RepositoryModel : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<DbContent.NorthwindEntities>();
            //It will dispose object when Request end from Glabal.asax
            Bind<IUnitOfWork>().To<UnitOfWork>().InScope(ctx=> HttpContext.Current);
        }
    }
}
