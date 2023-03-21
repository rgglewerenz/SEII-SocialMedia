using DatabaseInterop;
using DatabaseInterop.Modals;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess
{
    public class UserDA: BaseDA
    {
        public UserDA(IUnitOfWork unitOfWork) : base (unitOfWork)
        {

        }

        public List<UserTransferModal> GetUsers()
        {
            return UnitOfWork.UserRepository.GetQuery().Select(x => new UserTransferModal()
            {
                UserID = x.UserID,
                Email = x.Email
            }).ToList();
        }

        public UserTransferModal GetUserByID(int userID)
        {
            return UnitOfWork.UserRepository.GetQuery().Where(x => x.UserID == userID).Select(x => new UserTransferModal()
                {
                    UserID = x.UserID,
                    Email = x.Email
                }).FirstOrDefault();
        }

        public UserModal GetUserByEmail(string email)
        {
            return UnitOfWork.UserRepository.GetQuery().Where(x => x.Email == email).FirstOrDefault();
        }

        public async Task<UserTransferModal> GetUserByIDAsync(int userID)
        {
            return await (UnitOfWork.UserRepository.GetQuery().Where(x => x.UserID == userID).Select(x => new UserTransferModal()
            {
                UserID = x.UserID,
                Email = x.Email
            }).FirstOrDefaultAsync());
        }

        public UserTransferModal CreateUser(UserTransferModal model, string password)
        {
            try
            {
                var newModal = new UserModal()
                {
                    Email = model.Email,
                };

                newModal.CreatePasswordHash(password);

                UnitOfWork.StartTransaction();

                UnitOfWork.UserRepository.Insert(newModal);

                UnitOfWork.Save();

                UnitOfWork.CommitTransaction();
                
                return new UserTransferModal()
                {
                    Email = model.Email,
                    UserID = newModal.UserID
                };
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }
        }

        public UserTransferModal Authenticate(string email, string password)
        {
            var user = GetUserByEmail(email);

            if(user == null)
            {
                throw new Exception($"Unable to find the user with the email {email}");
            }

            if (!user.CheckPasswordHash(password))
            {
                throw new Exception("Invalid password");
            }

            return new UserTransferModal()
            {
                Email = email,
                UserID = user.UserID,
            };
        }

    }
}
