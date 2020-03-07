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
        [ForeignKey("Post")]
        public int PostId { set; get; }
        public virtual Post Post { set; get; }
        [ForeignKey("Tag")]
        public int TagId { set; get; }
        public virtual Tag Tag { set; get; }
    }
}
