using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [Required]
        public int CustomerId { set; get; }
        [Required]
        [MaxLength(255)]

        public string CustomerName { set; get; }

        [Required]
        [MaxLength(255)]
        public string CustomerAdderss { set; get; }
        
        [MaxLength(255)]
        public string CustomerEmail { set; get; }
        [Required]
        [MaxLength(255)]
        public string CustomerMobile { set; get; }
        
        [MaxLength(255)]
        public string CustomerMessage { set; get; }
        [Required]
        public int PaymentMethod { set; get; } = 1;
        public DateTime CreatedDate { set; get; } = DateTime.Now;
        public string CreatedBy { set; get; }
        public bool PaymentStatus { set; get; } = false;
        public bool Status { set; get; } = true;
        public virtual IEnumerable<OrderDetail> OrderDetails { set; get; }

        
    }
}
