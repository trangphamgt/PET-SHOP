using BOSS.Model.Models;
using BOSS.Service;
using BossShop.Web.Models.Response;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BossShop.Web.Infrastructure.Core
{
    public class ApiBaseController : ApiController
    {
        private IErrorService _errorService;

        public ApiBaseController(IErrorService errorService)
        {
            this._errorService = errorService;
        }
        

        //protected QueryListResponse<T> CreateListQueryResponse(Func<QueryListResponse<T>> function)
        //{
        //    QueryListResponse<T> response = null;
        //    try
        //    {
        //        response = function.Invoke();
        //    }
        //    catch(Exception ex)
        //    {
        //        LogError(ex);
        //        response.Count = 0;
        //    }

        //    return response;
        //}
        [NonAction]
        public void LogError(Exception ex)
        {
            try
            {
                Error error = new Error();
                error.CreatedDate = DateTime.Now;
                error.Message = ex.Message;
                error.StackTrace = ex.StackTrace;
                _errorService.Create(error);
                _errorService.SaveChanges();
            }
            catch { }
        }
    }
}