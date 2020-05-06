using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BossShop.Web.Models
{
    public class MenuViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string URL { set; get; }
        public int? DisplayOrder { set; get; }
        public int ParentId { set; get; }
        public bool IsAdmin { set; get; }
        public virtual MenuGroupViewModel MenuGroup { set; get; }
        public bool Status { set; get; }
    }
}