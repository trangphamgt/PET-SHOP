using BOSS.Data.Infrastructure;
using BOSS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Data.Repositories
{
    public interface ICommentRepository: IRepository<Comment>
    {
        IEnumerable<Comment> GetAllCommentByPost(int postId, out int totalRow);
        IEnumerable<Comment> GetAllCommentByComment(int commentId, out int totalRow);



    }
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<Comment> GetAllCommentByComment(int commentId, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetAllCommentByPost(int postId, out int totalRow)
        {
            var query = from c in DbContext.Comments
                        orderby c.CreatedDate descending
                        where c.Status != 0 && c.PostId == postId
                        select c;
            totalRow = query.Count();
            return query;
        }
    }
}
