using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Model.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [ForeignKey("Order")]
        public int OrderId { set; get; }
        public virtual Order Order { set; get; }

        [ForeignKey("Product")]
        public int ProductId { set; get; }
        public virtual Product Product { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
    }
}
