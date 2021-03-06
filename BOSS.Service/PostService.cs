﻿using BOSS.Data.Infrastructure;
using BOSS.Data.Repositories;
using BOSS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Service
{
    public interface IPostService
    {
        Post Add(Post post);
        Post Delete(int id);
        Post Delete(Post post);
        Post GetById(int id);
        void Update(Post post);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(int pageIndex, int page,out int totalRow);
        IEnumerable<Post> GetAllByTagPaging(int tag,int pageIndex, int page, int totalRow);
        IEnumerable<Post> GetAllByCategoryPost(int postCategory,  int pageIndex, int page,int totalRow);
        IEnumerable<Comment> GetAllCommentByPost(int postId, out int totalRow);
        IEnumerable<Comment> GetAllCommentByComment(int commentId, out int totalRow);
        Comment AddComment(Comment model);
        void SaveChanges();


    }
    public class PostService : IPostService
    {
        IPostRepository _postRepository;
        ICommentRepository _commentRepository;

        IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitofWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitofWork;
        }

        public Post Add(Post post)
        {
            return _postRepository.Add(post);
        }

        public Comment AddComment(Comment model)
        {
            return _commentRepository.Add(model);
        }

        public Post Delete(int id)
        {
            return _postRepository.Delete(id);
        }

        public Post Delete(Post post)
        {
            return _postRepository.Delete(post);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public IEnumerable<Post> GetAllByCategoryPost(int postCategory, int pageIndex, int page, int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.CategoryId == postCategory, out totalRow, pageIndex, page, new string[] { "PostTags" });
        }

        public IEnumerable<Post> GetAllByTagPaging(int tag,int pageIndex, int page, int totalRow)
        {
            return _postRepository.GetAllByTag(tag, pageIndex, page,out totalRow);
        }

        public IEnumerable<Comment> GetAllCommentByComment(int commentId, out int totalRow)
        {
            return _commentRepository.GetAllCommentByComment(commentId, out totalRow);
        }

        public IEnumerable<Comment> GetAllCommentByPost(int postId, out int totalRow)
        {
            return _commentRepository.GetAllCommentByPost(postId, out totalRow);
        }

        public IEnumerable<Post> GetAllPaging(int pageIndex, int page,out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status!=0,out totalRow, pageIndex, page);

        }

        public Post GetById(int id)
        {
            return _postRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
