using DatabaseInterop.Modals;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInterop
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly MainContext dbcontext;

        private DbContextTransaction _transaction;

        public UnitOfWork(IConfiguration _config)
        {
            try{
                SqlProviderServices _ = SqlProviderServices.Instance;
                dbcontext= new MainContext(_config);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #region Private Repos

        private GenericRepository<UserModal> _userRepository;

        private GenericRepository<PostModal> _postRepository;

        private GenericRepository<PostLikeModal> _postLikeRepository;

        #endregion Private Repos

        #region Public Repos

        public GenericRepository<UserModal> UserRepository {
            get
            {
                return _userRepository ?? (_userRepository = new GenericRepository<UserModal>(dbcontext));
            }
        }

        public GenericRepository<PostModal> PostRepository
        {
            get
            {
                return _postRepository ?? (_postRepository = new GenericRepository<PostModal>(dbcontext));
            }
        }

        public GenericRepository<PostLikeModal> PostLikeRepository
        {
            get
            {
                return _postLikeRepository ?? (_postLikeRepository = new GenericRepository<PostLikeModal>(dbcontext));
            }
        }


        #endregion  Public Repos

        public void Commit()
        {
            try
            {
                dbcontext.SaveChanges();
                _transaction.Commit();
            }
            catch(Exception ex)
            {
                _transaction.Rollback();
                throw ex;
            }
        }
        
        public void CommitTransaction()
        {
            try
            {
                _transaction.Commit();
            }
            catch(Exception ex)
            {
                _transaction.Rollback();
                throw ex;
            }
        }

        public IEnumerable<T> ExecuteReadQuery<T>(string query) where T : class
        {
            return dbcontext.Database.SqlQuery<T>(query).ToList();
        }

        public MainContext GetContext()
        {
            return dbcontext;
        }

        public void RollbackTransaction()
        {
            try
            {
                _transaction.Rollback(); 
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        public void Save()
        {
            dbcontext.SaveChanges();
        }

        public void StartTransaction()
        {
            _transaction = dbcontext.Database.BeginTransaction();
        }

        #region Dispose
        private bool Disposed;

        public void Dispose()
        {
            if(_transaction != null)
            {
                Commit();
            }
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        protected virtual void Dispose(bool disposing)
        {
            if(!Disposed)
            {
                if (disposing)
                {
                    dbcontext.Dispose();
                }
            }
            Disposed = true;
        }
        #endregion Dispose
    }
}
