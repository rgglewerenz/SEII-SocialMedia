using DataAcess;
using DatabaseInterop;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBAL
{
    public class PostBAL
    {
        private readonly PostDA _postDA;

        public PostBAL(IConfiguration _config)
        {
            _postDA = new PostDA(new UnitOfWork(_config));
        }

        public PostTransferModal CreatePost(PostTransferModal postTransferModal)
        {
            return _postDA.CreatePost(postTransferModal);
        }

        public bool DeletePost(int postID)
        {
            return _postDA.DeletePostByID(postID);
        }

        public PostTransferModal EditPost(PostTransferModal postTransferModal)
        {
            return _postDA.EditPost(postTransferModal);
        }

        public int GetMaxPostPageCount(int page_size)
        {
            return _postDA.GetMaxPostPageCount(page_size);
        }

        public int GetMaxPostPageCount(int page_size, int userID)
        {
            return _postDA.GetMaxPostPageCount(page_size, userID);
        }

        public PostTransferModal GetPostByID(int postID)
        {
            return _postDA.GetPostByID(postID);
        }

        public List<PostTransferModal> GetRecentPosts(int page_count, int page_size)
        {
            return _postDA.GetRecentPosts(page_count, page_size);
        }

        public List<PostTransferModal> GetRecentPosts(int page_count, int page_size, int userID)
        {
            return _postDA.GetRecentPosts(page_count, page_size, userID);
        }

        public bool LikePost(int postID, int userID)
        {
            return _postDA.LikePost(postID, userID);
        }

        public bool UnlikePost(int postID, int userID)
        {
            return _postDA.UnlikePost(postID, userID);
        }
    }
}
