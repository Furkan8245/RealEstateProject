using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

public class CacheRemoveAspect : MethodInterception
{
    private string _pattern;
    private ICacheManager _cacheManager;

    public CacheRemoveAspect(string pattern)
    {
        _pattern = pattern;
        
    }

    protected override void OnSuccess(IInvocation invocation)
    {
        _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        _cacheManager?.RemoveByPattern(_pattern);

        if (_cacheManager != null)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}