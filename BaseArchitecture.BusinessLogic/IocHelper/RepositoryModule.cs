using BaseArchitecture.DataAccess;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EF = BaseArchitecture.DbContent;

namespace BaseArchitecture.BusinessLogic.IocHelper
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<EF.NorthwindEntities>();
            Bind<IUnitOfWork>().To<UnitOfWork>().InScope(ctx => HttpContext.Current);
            Bind<ICustomerRepository>().To<CustomerRepository>();
        }
    }
}
