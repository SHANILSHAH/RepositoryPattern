using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF = BaseArchitecture.DbContent;
namespace BaseArchitecture.DataAccess
{
    public class CustomerRepository : GenericRepository<EF.Customer>, ICustomerRepository
    {
        IUnitOfWork _unitOfWork;
        public CustomerRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public EF.Customer GetCustomerByCustomerId(string Id)
        {
            return base.FindBy(x=>x.CustomerID.Equals(Id)).FirstOrDefault();
        }
    }
}
