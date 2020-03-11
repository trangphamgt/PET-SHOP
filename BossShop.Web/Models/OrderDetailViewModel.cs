using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BossShop.Web.Models
{
    public class OrderDetailViewModel
    {
        public int OrderId { set; get; }
        public virtual OrderViewModel Order { set; get; }
        public int ProductId { set; get; }
        public virtual ProductViewModel Product { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
    }
}