using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF = BaseArchitecture.DbContent;
namespace BaseArchitecture.DataAccess
{
    public interface ICustomerRepository : IGenericRepository<EF.Customer>
    {
        EF.Customer GetCustomerByCustomerId(string Id);

    }
}
