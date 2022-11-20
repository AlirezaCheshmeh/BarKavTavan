using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System.Security.Authentication;
using System.Security.Claims;

namespace BarKavTavan.Services
{
    public class webAuthorized : Attribute, IAuthorizationFilter
    {
        

        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            HttpContextAccessor d = new HttpContextAccessor();
            var result = d.HttpContext.Session.GetString("role");



            if (result != "1" && result == null)
            {
                throw new AuthenticationException("saas");
            }
        }
    }
}
