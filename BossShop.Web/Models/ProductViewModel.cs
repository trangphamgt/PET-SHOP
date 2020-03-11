using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BossShop.Web.Models
{
    public class ProductViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }

        public decimal? Price { set; get; }
        public decimal? PromotionPrice { set; get; }
        public int? Warranty { set; get; } = 6;
        public string Description { set; get; }
        public int? ParentId { set; get; }
        public int? DisplayOrder { set; get; }
        public string Image { set; get; }
        public bool HomeFlag { set; get; } = true;
        public int CategoryId { set; get; }
        public virtual ProductCategoryViewModel ProductCategory { set; get; }
        public DateTime? CreatedDate { set; get; }
        public int? CreatedBy { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public int? UpdatedBy { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }
        public int? Status { set; get; }
    }
}