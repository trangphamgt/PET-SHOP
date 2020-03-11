using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BossShop.Web.Models
{
    public class MenuGroupViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public virtual IEnumerable<MenuViewModel> Menus { set; get; }
    }
}