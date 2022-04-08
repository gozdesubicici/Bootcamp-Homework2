using Microsoft.AspNetCore.Mvc;

namespace AuthorizationAndResourceFilters.Filters
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(string izin)
           : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { izin };
        }
    }
}
