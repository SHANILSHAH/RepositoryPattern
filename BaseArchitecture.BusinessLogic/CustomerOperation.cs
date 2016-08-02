using BaseArchitecture.DataAccess;
using BaseArchitecture.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseArchitecture.BusinessLogic
{
    public class CustomerOperation
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerOperation(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public List<CustomerEntity> GetAll()
        {
            return _customerRepository.GetAll().Select(x => new CustomerEntity
            {
                CustomerId = x.CustomerID,
                Name = x.ContactName,
            }).ToList();
        }
    }
}
