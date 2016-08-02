using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Transactions;
using BaseArchitecture.DataAccess.OM;
namespace BaseArchitecture.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Member
        DbContent.NorthwindEntities _dbContext;
        bool _inTransaction = false;
        bool _disposed = false;
        DbContextTransaction _transaction;
        #endregion
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext as DbContent.NorthwindEntities;
        }
        #region interface Implementation
        public DbContent.NorthwindEntities DbContext
        {
            get
            {
                return _dbContext;
            }
        }
        public bool InTransaction
        {
            get
            {
                return _inTransaction;
            }
        }
        public void BeginTransaction()
        {
            _inTransaction = true;
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public OM.ActionStatus EndTransaction()
        {
            ActionStatus result = new ActionStatus { Message = string.Empty, Success = true };
            try
            {
                _transaction.Commit();
                _inTransaction = false;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;

        }

        public OM.ActionStatus SaveAndContinue()
        {
            ActionStatus result = new ActionStatus { Message = string.Empty, Success = true };
            try
            {
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public void RollBack()
        {
            try
            {
                _transaction.Rollback();
                _transaction.Dispose();
                _inTransaction = false;
            }
            catch
            {
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing && _dbContext != null && _inTransaction)
            {
                _transaction.Dispose();
            }
            if (disposing && _dbContext != null)
            {
                _dbContext.Dispose();
            }
            _disposed = true;

        }
        #endregion
    }
}
