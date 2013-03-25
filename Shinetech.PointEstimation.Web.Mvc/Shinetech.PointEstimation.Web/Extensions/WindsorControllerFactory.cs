using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace Shinetech.PointEstimation.Web.Mvc.Extensions
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer _container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public override void ReleaseController(IController controller)
        {
            _container.Release(controller);
            base.ReleaseController(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, System.Type controllerType)
        {
            if (controllerType == null)
                return null;

            try
            {
                return (IController)_container.Resolve(controllerType);
            }
            catch (Exception)
            {
                return base.GetControllerInstance(requestContext, controllerType);
            }
        }
    }
}