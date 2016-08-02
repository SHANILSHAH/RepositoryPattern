using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
namespace BaseArchitecture.DataAccess.NinjectCommon
{
    public class NinjectHelper
    {
        public static IKernel Kernel { get; private set; }
        public static void Initialize()
        {
            Kernel = CreateKernel();
        }
        #region PrivateMember
        private static IKernel CreateKernel()
        {
            var Kernel = new StandardKernel();
            try
            {
                Kernel.Load<RepositoryModel>();
            }
            catch (Exception)
            {
                if (!Kernel.IsDisposed)
                    Kernel.Dispose();
                throw;
            }
            return Kernel;
        }
        #endregion
    }
}
