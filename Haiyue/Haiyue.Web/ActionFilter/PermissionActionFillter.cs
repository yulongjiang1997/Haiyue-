using Haiyue.Model;
using Haiyue.Service.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haiyue.Web.ActionFilter
{
    public class PermissionActionFillter : ActionFilterAttribute
    {
        private readonly IUserservice _service;
        public PermissionActionFillter(IUserservice service)
        {
            _service = service;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            HttpRequest request = context.HttpContext.Request;
            var path = request.Path.Value;
            if (!path.Contains("Login"))
            {
                var token = request.Headers["Token"].ToString();
                var userId = request.Headers["UserId"].ToString();
                if (!_service.CheckTokenTimeOut(userId, token))
                {
                    context.Result = new JsonResult(new ReturnData<object>
                    {
                        Message = "Error 401 No Access",
                        Success = false,
                    });
                    context.HttpContext.Response.StatusCode = 401;
                }
                if (path.Contains("Expenditure") || path.Contains("Game") ||
                    path.Contains("User") || path.Contains("Currency"))
                {
                    if (!_service.CheckIsAdmin(userId))
                    {
                        context.Result = new JsonResult(new ReturnData<object>
                        {
                            Message = "Error 401 No Admin Access",
                            Success = false,
                        });
                        context.HttpContext.Response.StatusCode = 401;
                    }
                }
                base.OnActionExecuting(context);
            }
        }
    }
    public class CheckAdmin : ActionFilterAttribute
    {
        private readonly IUserservice _service;
        public CheckAdmin(IUserservice service)
        {
            _service = service;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            HttpRequest request = context.HttpContext.Request;
            var isLoing = request.Path.Value.Contains("Login");
            if (!isLoing)
            {
                var userId = request.Headers["UserId"].ToString();
                if (!_service.CheckIsAdmin(userId))
                {
                    context.Result = new JsonResult(new ReturnData<object>
                    {
                        Message = "Error 401 No Access",
                        Success = false,
                    });
                    context.HttpContext.Response.StatusCode = 401;
                }
                base.OnActionExecuting(context);
            }
        }
    }
}
