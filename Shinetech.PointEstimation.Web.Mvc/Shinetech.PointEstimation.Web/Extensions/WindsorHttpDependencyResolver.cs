using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;
using Castle.Windsor;

namespace Shinetech.PointEstimation.Web.Mvc.Extensions
{
    public class WindsorHttpDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IWindsorContainer _container;
 

        public WindsorHttpDependencyResolver(IWindsorContainer container) {
            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(this._container);
        }

        public object GetService(Type serviceType)
        {
            // for ModelMetadataProvider and other MVC related types that may have been added to the container
            // check the lifecycle of these registrations
            return _container.Kernel.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType) ? _container.ResolveAll(serviceType) as IEnumerable<object> : Enumerable.Empty<object>();
        }

        public void Dispose()
        {
            // Nothing created so nothing to dispose - kernel will take care of its own
        }
    }
}