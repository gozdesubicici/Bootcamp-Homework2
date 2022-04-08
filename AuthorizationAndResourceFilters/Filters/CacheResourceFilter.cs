using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthorizationAndResourceFilters.Filters
{
    public class CacheResourceFilter : IResourceFilter
    {
		// İlk olarak, IResourceFilter arabirimini uygulayan bir CacheResourceFilter sınıfı tanımlayalım.Kaynak filtresinde OnResourceExecuting() öncesi yöntemi ve OnResourceExecuted() sonrası yöntemi vardır. Önbelleğe alınan değeri tutmak için bir sözlük nesnesi _cache ve Önbellek(cache) anahtarını depolamak için bir string değeri _cacheKey tanımlayalım:
		private static readonly Dictionary<string, object> _cache
				= new Dictionary<string, object>();
		private string _cacheKey;

		public void OnResourceExecuting(ResourceExecutingContext context)
		{
			_cacheKey = context.HttpContext.Request.Path.ToString();
			if (_cache.ContainsKey(_cacheKey))
			{
				var cachedValue = _cache[_cacheKey] as string;
				if (cachedValue != null)
				{
					context.Result = new ContentResult()
					{ Content = cachedValue };
				}
			}
		}

		public void OnResourceExecuted(ResourceExecutedContext context)
		{
			if (!String.IsNullOrEmpty(_cacheKey) && !_cache.ContainsKey(_cacheKey))
			{
				var result = context.Result as ContentResult;
				if (result != null)
				{
					_cache.Add(_cacheKey, result.Content);
				}
			}
		}

		// OnResourceExecuting() yönteminde, _cacheKey'in _cache sözlüğünde olup olmadığını kontrol edebiliriz. Varsa, context.Result'u önbelleğe alınmış değerle ayarlarız. Bağlam.Sonuç (context.Result) özelliğini ayarlayarak filtre boru(pipeline) hattına kısa devre yaptırabiliriz. OnResourceExecuting() yönteminde, _cacheKey'in _cache'de zaten mevcut olup olmadığını kontrol ederiz.Değilse, context.Result değerini _cache'e ekleyeceğiz. Ardından bu filtre için bir öznitelik(attribute) oluşturalım:
	}
}
