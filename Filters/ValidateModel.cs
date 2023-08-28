using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SNIAPI.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionContext.ModelState);
            }
            var v = HttpContext.Current.User.Identity.Name;
            if (actionContext.RequestContext.Principal.Identity.IsAuthenticated)
            {
                var userName = actionContext.RequestContext.Principal.Identity.Name;
            }
        }
 
    }
}