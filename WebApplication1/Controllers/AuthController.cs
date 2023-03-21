using DatabaseBAL;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserBAL _userBAL;

        public AuthController(IConfiguration _config)
        {
            _userBAL = new UserBAL(_config);
        }

        #region GET

        [HttpGet("AuthenticateUser")]
        public UserTransferModal AuthenticateUser(string email, string password)
        {
            return _userBAL.AuthenticateUser(email, password);
        }

        #endregion GET

        #region POST

        #endregion POST


    }
}
