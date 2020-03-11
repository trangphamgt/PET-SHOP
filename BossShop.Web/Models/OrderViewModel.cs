using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BossShop.Web.Models
{
    public class OrderViewModel
    {
        public int Id { set; get; }
        public int CustomerId { set; get; }
        public string CustomerName { set; get; }
        public string CustomerAdderss { set; get; }
        public string CustomerEmail { set; get; }
        public string CustomerMobile { set; get; }
        public string CustomerMessage { set; get; }
        public int PaymentMethod { set; get; } = 1;
        public DateTime CreatedDate { set; get; } = DateTime.Now;
        public string CreatedBy { set; get; }
        public bool PaymentStatus { set; get; } = false;
        public bool Status { set; get; } = true;
        public virtual IEnumerable<OrderDetailViewModel> OrderDetails { set; get; }
    }
}