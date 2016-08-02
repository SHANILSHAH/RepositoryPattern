using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BaseArchitecture.DataAccess.OM;
namespace BaseArchitecture.DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        #region Private Member
        private IUnitOfWork _unitOfWork { get; set; }
        private IDbSet<T> _entities { get; set; }
        private bool _isInLocalTran { get; set; }
        #endregion
        #region PublicMethod
        public IDbSet<T> Entities
        {
            get
            {
                if (this._entities == null)
                    _entities = _unitOfWork.DbContext.Set<T>();
                return _entities;
            }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor, Need to pass objec of Unit of work for transaction management and other database related operation.
        /// </summary>
        /// <param name="unitOfWork"></param>
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        /// <summary>
        /// This function will be used to create new entity for specific model based on entityframework dbContext
        /// </summary>
        /// <returns>It will return template</returns>
        public T CreateNewEntity()
        {
            return Entities.Create();
        }
        /// <summary>
        /// This function will be used to find recor from database based on primarykey
        /// </summary>
        /// <param name="id">value of primary key</param>
        /// <returns></returns>
        public T FindById(int id)
        {
            return this.Entities.Find(id);
        }

        public OM.ActionStatus Insert(T entity)
        {

            ActionStatus result = new ActionStatus { Message = string.Empty, Success = true };
            try
            {
                if (this.Entities == null)
                    throw new Exception("Need to initilize entity object");


                if (!_unitOfWork.InTransaction)
                {
                    _isInLocalTran = true;
                    _unitOfWork.BeginTransaction();
                }
                this.Entities.Add(entity);
                result = _unitOfWork.SaveAndContinue();
                if (_isInLocalTran)
                {
                    if (result.Success)
                        _unitOfWork.EndTransaction();
                    else
                        _unitOfWork.RollBack();
                    _isInLocalTran = false;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;

        }

        public OM.ActionStatus Update(T entity)
        {
            ActionStatus result = new ActionStatus { Message = string.Empty, Success = true };
            try
            {
                if (this.Entities == null)
                    throw new Exception("Need to initilize entity object");

                if (!_unitOfWork.InTransaction)
                {
                    _isInLocalTran = true;
                    _unitOfWork.BeginTransaction();
                }
                _unitOfWork.DbContext.Entry(entity).State = EntityState.Modified;
                result = _unitOfWork.SaveAndContinue();
                if (_isInLocalTran)
                {
                    if (result.Success)
                        _unitOfWork.EndTransaction();
                    else
                        _unitOfWork.RollBack();
                    _isInLocalTran = false;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public OM.ActionStatus Delete(T entity)
        {
            ActionStatus result = new ActionStatus { Message = string.Empty, Success = true };
            try
            {
                if (this.Entities == null)
                    throw new Exception("Need to initilize entity object");

                if (!_unitOfWork.InTransaction)
                {
                    _isInLocalTran = true;
                    _unitOfWork.BeginTransaction();
                }
                this.Entities.Remove(entity);
                result = _unitOfWork.SaveAndContinue();
                if (_isInLocalTran)
                {
                    if (result.Success)
                        _unitOfWork.EndTransaction();
                    else
                        _unitOfWork.RollBack();
                    _isInLocalTran = false;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public IQueryable<T> GetAll()
        {
            return this.Entities;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return this.Entities.Where(predicate);
        }
    }
}
