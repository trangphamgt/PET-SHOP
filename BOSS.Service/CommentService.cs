using BOSS.Data.Infrastructure;
using BOSS.Data.Repositories;
using BOSS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Service
{
    public interface ICommentService
    {
        Comment Add(Comment comment);
        Comment GetComment(int id);
        void Update(Comment comment);
        Comment Delete(Comment comment);
        Comment Delete(int id);
        IEnumerable<Comment> GetAllCommentByPost(int id, out int totalRow);
        IEnumerable<Comment> GetAllCommentByComment(int id, out int totalRow);
        void SaveChanges();
    }
    public class CommentService : ICommentService
    {
        ICommentRepository _commentrepository;
        IUnitofWork _unitOfWork;

        public CommentService(ICommentRepository commentRepository, IUnitofWork unitofWork)
        {
            this._commentrepository = commentRepository;
            this._unitOfWork = unitofWork;
        }

        public Comment Add(Comment comment)
        {
            return _commentrepository.Add(comment);
        }

        public Comment Delete(Comment comment)
        {
            return _commentrepository.Delete(comment);
        }

        public Comment Delete(int id)
        {
            return _commentrepository.Delete(id);
        }

        public IEnumerable<Comment> GetAllCommentByComment(int id, out int totalRow)
        {
            return _commentrepository.GetAllCommentByComment(id, out totalRow);
        }

        public IEnumerable<Comment> GetAllCommentByPost(int id, out int totalRow)
        {
            return _commentrepository.GetAllCommentByPost(id, out totalRow);
        }

        public Comment GetComment(int id)
        {
            return _commentrepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Comment comment)
        {
            _commentrepository.Update(comment);
        }
    }
}
