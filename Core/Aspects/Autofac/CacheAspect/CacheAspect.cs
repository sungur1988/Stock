using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.CacheAspect
{
    public class CacheAspect : MethodInterception
    {
        private ICacheManager _cacheManager;
        private int _duration;
        public CacheAspect(int duration)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var methodName = $"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}";
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(',', arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
        }
    }
}
