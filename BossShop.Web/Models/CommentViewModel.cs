using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BossShop.Web.Models
{
    public class CommentViewModel
    {
        public int Id { set; get; }
        public string Content { set; get; }

        public int? CommentId { set; get; }
        public int? PostId { set; get; }
        public DateTime? CreatedDate { set; get; }
        public int? CreatedBy { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public int? UpdatedBy { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }
        public int? Status { set; get; }
    }
}