using Microsoft.AspNetCore.Mvc;

namespace AuthorizationAndResourceFilters.Filters
{
	public class CacheResourceAttribute : TypeFilterAttribute
	{
		public CacheResourceAttribute()
			: base(typeof(CacheResourceFilter))
		{
		}
	}
}
