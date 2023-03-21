using DatabaseInterop.Modals;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInterop
{
    public interface IUnitOfWork
    {
        #region Methods
        void Commit();
        void Dispose();
        void Save();
        void StartTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        IEnumerable<T> ExecuteReadQuery<T>(string query) where T : class;
        MainContext GetContext();
        #endregion Methods

        #region Repositories

        GenericRepository<UserModal> UserRepository { get; }
        GenericRepository<PostModal> PostRepository { get; }
        GenericRepository<PostLikeModal> PostLikeRepository { get; }

        #endregion Repositories
    }
}
