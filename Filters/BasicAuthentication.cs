using SNIAPI.Exceptions;
using SNIAPI.Models;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SNIAPI.Filters
{
	/// <summary>
	/// 
	/// </summary>
    public class BasicAuthentication : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if (actionContext.Request.Headers.Authorization == null)
            {
               // Login / logout calls without tokens allow this call to controller
            }
            else
            {
                var user = HttpContext.Current.User;
                 
                string authenticationToken = actionContext.Request.Headers
                                            .Authorization.Parameter;
                 
                if(!IsValidSession(authenticationToken, user))
                {
					actionContext.Response = new System.Net.Http.HttpResponseMessage(HttpStatusCode.Unauthorized);
					//"A session exists in another device. please retry;

				}
            }
        }

        private bool IsValidSession(string authenticationToken, System.Security.Principal.IPrincipal principal)
        {
            bool success = false;
			var claim = ((ClaimsPrincipal)principal);

			if (claim == null)
			{
				return false;
			}
			var emailid = claim.Claims.Where(a => a.Type.Contains("emailaddress")).Select(a=>a.Value).FirstOrDefault();
            
			using (
				SNIEntities dbModel = new SNIEntities())
			{
				var userDetails = dbModel.Tbl_SessionLogin
									.Where(x => 
									x.UserEmailId.Trim().ToLower() == emailid.Trim().ToLower()
									 && x.Token.Trim().ToLower() == authenticationToken.Trim().ToLower()
									 && x.IsActive == true
									 && x.UdateTimeStamp.HasValue 
									)
									.OrderByDescending(a => a.UdateTimeStamp)
									.FirstOrDefault();
				if (userDetails != null

					//&& userDetails.ForgotPasswordGeneratedOn.HasValue &&
					&& userDetails.UdateTimeStamp.Value.AddMinutes(userDetails.IdleTimemin.Value) > DateTime.Now
					)
				{

					//throw new Exception("For this login a session already exists in same device or different device. Try after 30 minutes.!");
					// Continue valid session

					userDetails.UdateTimeStamp = DateTime.Now;
					dbModel.SaveChanges();
					success = true;
				}
				else
				{

					// Throw error 
					success = false;
					new CustomException(HttpStatusCode.Unauthorized, "Session expired / A session already exists in another device. Retry after sometime");
					
				}
				
			} 
			return success;
        }
    }
}