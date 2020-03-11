using BOSS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BossShop.Web.Models
{
    public class PostViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public int CategoryId { set; get; }

        public int? ViewCount { set; get; } = 0;
        public string Description { set; get; }
        public string Content { set; get; }
        public string Image { set; get; }
        public bool HomeFlag { set; get; } = true;
        public bool HotFlag { set; get; } = false;
        public virtual IEnumerable<PostTagViewModel> PostTags { set; get; }
        public DateTime? CreatedDate { set; get; }
        public int? CreatedBy { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public int? UpdatedBy { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }
        public int? Status { set; get; }
    }
}