using CoreApp31.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp31.CustomFilters
{
    public class MyExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IModelMetadataProvider modelMetadata;
        private readonly VodafoneExceptionDbContext dbContext;

        /// <summary>
        /// Inject IModelMetadataProvider
        /// This interface is resolved by MvcOptions in ConfigureServices()
        /// </summary>
        public MyExceptionFilterAttribute(IModelMetadataProvider modelMetadata, VodafoneExceptionDbContext dbContext)
        {
            this.modelMetadata = modelMetadata;
            this.dbContext = dbContext;
        }

        public override void OnException(ExceptionContext context)
        {
            // 1. Exception Is handled so that Request Processing is completed
            // and the result return process starts
            context.ExceptionHandled = true;
            // 2. Read the exception Message
            string message = context.Exception.Message;
            // 3. Returning result
            var viewResult = new ViewResult();
            // 3a. Create a ViewDataDiciotnary and define Key/Values for it
            var viewData = new ViewDataDictionary(modelMetadata, context.ModelState);
            dbContext.ExceptionLogs.Add(new ExceptionLog
            {
                ControllerName = context.RouteData.Values["controller"].ToString(),
                ActionName = context.RouteData.Values["action"].ToString(),
                Date = DateTime.Now,
                ExceptionMesaage = message,
                StackTrace= context.Exception.StackTrace
            }) 
            ;
            dbContext.SaveChanges();
            // 3b. define keys for viewData
            viewData["controller"] = context.RouteData.Values["controller"];
            viewData["action"] = context.RouteData.Values["action"];
            viewData["errorMessage"] = message;
            viewResult.ViewName = "CustomError";
            viewResult.ViewData = viewData;
            context.Result = viewResult;
        }
    }
}
