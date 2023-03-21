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

        public PostTransferModal GetPostByID(int postID)
        {
            return _postDA.GetPostByID(postID);
        }
    }
}
