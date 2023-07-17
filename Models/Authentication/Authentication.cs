using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace BaiTapLonWeb.Models.Authentication
{
    public class Authentication : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {


            if (context.HttpContext.Session.GetString("maKH") == null)
            {
                
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "Controller", "AccessClient" }, { "Action", "LoginClient" } }
                );
                base.OnActionExecuting(context);
            }
        }


    }
}
