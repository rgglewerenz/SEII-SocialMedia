using DataAcess;
using DatabaseInterop;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DatabaseBAL
{
    public class UserBAL
    {
        private readonly UserDA _userDA;

        public UserBAL(IConfiguration _config)
        {
            _userDA = new UserDA(new UnitOfWork(_config));
        }

        public UserTransferModal AuthenticateUser(string email, string password)
        {
            return _userDA.Authenticate(email, password);
        }

        public UserTransferModal CreateUser(string email, string password)
        {
            return _userDA.CreateUser(new UserTransferModal() { Email = email}, password);
        }

        public UserTransferModal GetUserByID(int userID)
        {
            return _userDA.GetUserByID(userID);
        }

        public List<UserTransferModal> GetUsers()
        {
            return _userDA.GetUsers();
        }
    }
}