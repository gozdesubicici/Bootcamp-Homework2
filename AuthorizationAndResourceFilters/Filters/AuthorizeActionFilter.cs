using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace AuthorizationAndResourceFilters.Filters
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        private readonly string _izin;
        public AuthorizeActionFilter(string izin)
        {
            _izin = izin;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isAuthorized = CheckUserPermission(context.HttpContext.User, _izin);
            if (!isAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }
        private bool CheckUserPermission(ClaimsPrincipal user, string izin)
        {
            // Kullanıcı iznini kontrol etme işi buraya yazılır

            // Bu kullanıcının yalnızca okuma izni olduğunu varsayalım
            return izin == "Read";
        }
    }
}
