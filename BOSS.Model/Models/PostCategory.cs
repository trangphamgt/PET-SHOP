using BOSS.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Model.Models
{
    [Table("PostCategories")]
    public class PostCategory : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [MaxLength(255)]
        [Column(TypeName = "nvarchar")]
        public string Name { set; get; }
        [MaxLength(255)]
        public string Alias { set; get; }
        [MaxLength(255)]
        [Column(TypeName = "nvarchar")]
        public string Description { set; get; }
        public int? ParentId { set; get; }
        public int? DisplayOrder { set; get; }
        public string Image { set; get; }
        public bool HomeFlag { set; get; } = true;

    }
}
