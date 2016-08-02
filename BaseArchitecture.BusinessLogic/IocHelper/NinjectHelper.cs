using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseArchitecture.BusinessLogic.IocHelper
{
   public static class NinjectHelper
    {
       public static IKernel Kernel { get { return _kernel; } }
       private static IKernel _kernel { get; set; }
       public static void Initialize()
       {
           _kernel = KernelCreator();
       }
       public static IKernel KernelCreator()
       {
           var Kernel = new StandardKernel();

           try
           {
               Kernel.Load<RepositoryModule>();
           }
           catch
           {
               if (!Kernel.IsDisposed)
               Kernel.Dispose();
           }
           return Kernel;
       }
    }
}
