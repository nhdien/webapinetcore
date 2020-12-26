﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using WebAPINetCore.Entities;

namespace WebAPINetCore.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public AuthorizeAttribute()
        {

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var account = (Account)context.HttpContext.Items["Account"];

            if (account == null)
            {
                context.Result = new JsonResult(new
                {
                    message = "Unauthorized"
                })
                { 
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
