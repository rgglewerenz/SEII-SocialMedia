using DatabaseBAL;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserBAL _userBAL;

        public UserController(IConfiguration _config)
        {
            _userBAL = new UserBAL(_config);
        }

        #region GET

        [HttpGet("GetUsers")]
        public List<UserTransferModal> GetUsers()
        {
            return _userBAL.GetUsers();
        }

        [HttpGet("GetUserByID")]
        public UserTransferModal GetUserByID(int userID)
        {
            return _userBAL.GetUserByID(userID);
        }

        #endregion GET

        #region POST

        [HttpPost("CreateUser")]
        public UserTransferModal CreateUser(string email, string password)
        {
            return _userBAL.CreateUser(email, password);
        }

        #endregion POST


    }
}
