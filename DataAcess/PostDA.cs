using DatabaseInterop;
using DatabaseInterop.Modals;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess
{
    public class PostDA:BaseDA
    {
        public PostDA(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {

        }

        public PostModal GetPostModalByID(int postID)
        {
            return UnitOfWork.PostRepository.GetQuery().Where(x => x.PostID == postID).FirstOrDefault();
        }

        public PostTransferModal GetPostByID(int postID)
        {
            var post = GetPostModalByID(postID);

            if(post == null)
            {
                throw new Exception($"Unable to find post with the id {postID}");
            }

            var postLikeCount = UnitOfWork.PostLikeRepository.GetQuery().Where(x => x.PostID == postID).Count();

            return new PostTransferModal()
            {
                PostID = postID,
                Caption = post.Caption,
                ImageURL = post.ImageURL,
                UsertID = post.UserID,
                LikeCount = postLikeCount
            };

        }

        public PostTransferModal CreatePost(PostTransferModal newPost)
        {
            try
            {
                var postModel = new PostModal()
                {
                    Caption = newPost.Caption,
                    UserID = newPost.UsertID,
                    ImageURL = newPost.ImageURL
                };
                StartTransaction();

                UnitOfWork.PostRepository.Insert(postModel);

                UnitOfWork.Save();

                CommitTransaction();

                newPost.PostID = postModel.PostID;

                return newPost;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            } 
        }

        public bool DeletePostByID(int postID)
        {
            try
            {
                StartTransaction();

                var post = GetPostModalByID(postID);

                if(post == null)
                {
                    throw new Exception($"Unable to find a post with id {postID}");
                }

                var postLikes = UnitOfWork.PostLikeRepository.GetQuery().Where(x => x.PostID == postID).ToArray();

                foreach(var item in postLikes)
                {
                    UnitOfWork.PostLikeRepository.Delete(item);
                }

                UnitOfWork.Save();

                UnitOfWork.PostRepository.Delete(post);

                UnitOfWork.Save();

                CommitTransaction();

                return true;
            }catch(Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }
        }

        public List<PostTransferModal> GetRecentPosts(int page_count, int page_size)
        {
            return UnitOfWork.PostRepository.GetQuery()
                    .OrderByDescending(x => x.PostID)
                        .Skip(page_size * page_count)
                            .Take(page_size)
                                .ToImmutableList()
                                    .Select(x => GetPostByID(x.PostID))
                                        .ToList();
        }

        public int GetMaxPostPageCount(int page_size)
        {
            return (int) Math.Ceiling((double)UnitOfWork.PostRepository.GetQuery().Count() / (double)page_size);
        }

        public PostTransferModal EditPost(PostTransferModal postTransferModal)
        {
            try
            {
                StartTransaction();

                var post = GetPostModalByID(postTransferModal.PostID);

                post.ImageURL = postTransferModal.ImageURL;
                post.Caption = postTransferModal.Caption;

                UnitOfWork.PostRepository.Update(post);

                UnitOfWork.Save();

                CommitTransaction();

                return GetPostByID(postTransferModal.PostID);
            }catch(Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }
        }
    }
}
