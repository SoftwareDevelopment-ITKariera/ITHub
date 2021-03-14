using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJourney.Filters
{
    public class UserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Session.GetInt32("loggedUserId").HasValue)
            {
                context.HttpContext.Response.Redirect("/Auth/Login");
                context.Result = new EmptyResult();
            }
            base.OnActionExecuting(context);
        }
    }
}
