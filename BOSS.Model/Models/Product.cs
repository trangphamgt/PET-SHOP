using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Model.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [MaxLength(255)]
        [Column(TypeName = "nvarchar")]
        public string Name { set; get; }
        [MaxLength(255)]
        public string Alias { set; get; }
        
        public decimal? Price { set; get; }
        public decimal? PromotionPrice { set; get; }
        public int? Warranty { set; get; } = 6;
        
        [Column(TypeName = "nvarchar")]
        public string Description { set; get; }
        public int? ParentId { set; get; }
        public int? DisplayOrder { set; get; }
        public string Image { set; get; }
        public bool HomeFlag { set; get; } = true;
        [Required]
        [ForeignKey("ProductCategory")]
        public int CategoryId { set; get; }
        public virtual ProductCategory ProductCategory { set; get; }
    }
}
