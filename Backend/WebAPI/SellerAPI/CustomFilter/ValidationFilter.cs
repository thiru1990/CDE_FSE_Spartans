using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SellerAPI.CustomFilter
{
    public class ValidationFilter:IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Keys.SelectMany(keys => context.ModelState[keys].Errors.Select(x=> x.ErrorMessage).ToList());
                //Implement Custom Exception here.
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }
                
        }

        public void OnActionExecuting(ActionExecutingContext context)
        { }
    }
}
