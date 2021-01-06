using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PersonalBlog.Interfaces;

namespace PersonalBlog.Services
{
    public class ProtectorAttribute : Attribute, IActionFilter
    {
        private readonly IAuthorizer _authorizer;

        public ProtectorAttribute(IAuthorizer authorizer)
        {
            _authorizer = authorizer;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_authorizer.IsAuthorized())
            {
                context.Result = new RedirectToActionResult("Error", "Home", null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }
    }
}
