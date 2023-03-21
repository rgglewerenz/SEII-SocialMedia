using DatabaseBAL;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace PetSocialMediaAPI.Controllers
{
    [Route("api/[controller]")]
    public class PostController:Controller
    {
        private readonly PostBAL _postBAL;

        public PostController(IConfiguration _config)
        {
            _postBAL = new PostBAL(_config);
        }

        #region GET

        [HttpGet("GetPostByID")]
        public PostTransferModal GetPostByID(int postID)
        {
            return _postBAL.GetPostByID(postID);
        }

        #endregion GET

        #region POST

        [HttpPost("CreatePost")]
        public PostTransferModal CreatePost(string caption, string image_url, int userID)
        {
            return _postBAL.CreatePost(new PostTransferModal() { Caption = caption, ImageURL = image_url, UsertID = userID });
        }

        #endregion POST

        #region DELETE

        [HttpDelete("DeletePost")]
        public bool DeletePost(int postID)
        {
            return _postBAL.DeletePost(postID);
        }
        #endregion DELETE


    }
}
