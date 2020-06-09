using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BossShop.Web.Models.Response
{
    public class QueryListResponse<T> where T : class
    {
        public IEnumerable<T> Items { set; get; }
        public int Count { set; get; }
        public int StatusCode { set; get; }
        public bool IsError { set; get; }
    }
}