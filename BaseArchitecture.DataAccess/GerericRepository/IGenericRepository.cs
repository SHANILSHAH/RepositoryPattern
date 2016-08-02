using BaseArchitecture.DataAccess.OM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseArchitecture.DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        T CreateNewEntity();
        T FindById(int id);
        ActionStatus Insert(T entity);
        ActionStatus Update(T entity);
        ActionStatus Delete(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

    }
}
