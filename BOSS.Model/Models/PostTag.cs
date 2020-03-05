using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Model.Models
{
    [Table("PostTags")]
    public class PostTag
    {
        [Key]
        public int PostId { set; get; }
        [Key]
        public int TagId { set; get; }
    }
}
