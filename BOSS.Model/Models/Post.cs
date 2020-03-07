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
    [Table("Posts")]
    public class Post : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [MaxLength(255)]
        [Column(TypeName = "nvarchar")]
        public string Name { set; get; }
        [MaxLength(255)]
        public string Alias { set; get; }
        [Required]
        public int CategoryId { set; get; }
        
        public int? ViewCount { set; get; } = 0;

        [Column(TypeName = "nvarchar")]
        public string Description { set; get; }

        [Column(TypeName = "ntext")]
        public string Content { set; get; }
        public string Image { set; get; }
        public bool HomeFlag { set; get; } = true;
        public bool HotFlag { set; get; } = false;
        public virtual IEnumerable<PostTag> PostTags { set; get; }
    }
}
