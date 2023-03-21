using DatabaseInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess
{
    public class BaseDA : IDisposable, IBaseDA
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public void CommitTransaction()
        {
            UnitOfWork.Commit();
        }

        public void RollbackTransaction()
        {
            UnitOfWork.RollbackTransaction();
        }

        public void StartTransaction()
        {
            UnitOfWork.StartTransaction();
        }

        protected BaseDA(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #region Dispose
        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    UnitOfWork.Dispose();
                }
                _disposed = true;
            }
        }


        #endregion Dispose
    }
}
