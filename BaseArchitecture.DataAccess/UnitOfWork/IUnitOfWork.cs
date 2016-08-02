using BaseArchitecture.DataAccess.OM;
using BaseArchitecture.DbContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseArchitecture.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        NorthwindEntities DbContext { get; }
        bool InTransaction { get;  }
        void BeginTransaction();
        ActionStatus EndTransaction();
        ActionStatus SaveAndContinue();
        void RollBack();
    }
}
