﻿using BOSS.Model.Models;
using BOSS.Service;
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

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;
            try
            {
                response = function.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message, Configuration.Formatters.JsonFormatter);
            }
            catch (DbUpdateException dbEx)
            {
                LogError(dbEx);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message, Configuration.Formatters.JsonFormatter);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message, Configuration.Formatters.JsonFormatter);
            }
            return response;
        }

        private void LogError(Exception ex)
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