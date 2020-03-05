using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Model.Abstract
{
    public interface IAuditable
    {
        DateTime CreatedDate { set; get; }
        int CreatedBy { set; get; }
        DateTime? UpdatedDate { set; get; }
        int UpdatedBy { set; get; }
        string MetaKeyword { set; get; }
        string MetaDescription { set; get; }
        bool Status { set; get; }
    }
}
