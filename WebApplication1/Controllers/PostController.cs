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

        [HttpGet("GetMaxPostPageCount")]
        public int GetMaxPostPageCount(int page_size)
        {
            return _postBAL.GetMaxPostPageCount(page_size);
        }

        [HttpGet("GetRecentPosts")]
        public List<PostTransferModal> GetRecentPosts(int page_count = 0,int page_size = 10)
        {
            return _postBAL.GetRecentPosts(page_count, page_size);
        }

        #endregion GET

        #region POST

        [HttpPost("CreatePost")]
        public PostTransferModal CreatePost(string caption, string image_url, int userID)
        {
            return _postBAL.CreatePost(new PostTransferModal() { Caption = caption, ImageURL = image_url, UsertID = userID });
        }

        [HttpPost("EditPost")]
        public PostTransferModal EditPost(string caption, string image_url, int postID)
        {
            return _postBAL.EditPost(new PostTransferModal() { Caption = caption, PostID = postID, ImageURL = image_url });
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
