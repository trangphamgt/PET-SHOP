using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BossShop.Web.Models
{
    public class TagViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Type { set; get; }
        public virtual IEnumerable<PostTagViewModel> PostTags { set; get; }
    }
}