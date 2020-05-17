using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BossShop.Web.Models.Response
{
    public class ApiResponse<T> where T : class
    {
        public string Version { set; get; }
        public int? StatusCode { set; get; }
        public string Message { set; get; }
        public bool? IsError { set; get; }
        public T Result { set; get; }
    }
}