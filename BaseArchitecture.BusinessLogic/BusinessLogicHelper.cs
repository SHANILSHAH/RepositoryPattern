using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
namespace BaseArchitecture.BusinessLogic
{
    public class BusinessLogicHelper
    {
        private static BusinessLogicHelper instance;
        private BusinessLogicHelper()
        {
        }
        public static BusinessLogicHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new BusinessLogicHelper();
                return instance;
            }
        }

        public CustomerOperation CustoperOperation
        {
            get
            {
                return IocHelper.NinjectHelper.Kernel.Get<CustomerOperation>();
            }
        }

    }
}
