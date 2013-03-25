using System.Web.Mvc;
using Castle.Facilities.AutoTx;
using Castle.Facilities.FactorySupport;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Shinetech.PointEstimation.Domain;
using Shinetech.PointEstimation.Web.Mvc.Extensions;

namespace Shinetech.PointEstimation.Web.Extensions
{
    public static class WindsorContainerBootstrapper
    {
        private static IWindsorContainer container;

        public static IWindsorContainer Container
        {
            get { return container; }
        }

        public static IWindsorContainer Bootstrap()
        {
            if (container != null)
                return container;
            container = new WindsorContainer();
            container.AddFacility<AutoTxFacility>();
            container.Install(FromAssembly.This());
            container.Install(FromAssembly.Containing<EstimationPoint>());
            container.Register(Component.For<IWindsorContainer>().Instance(container));
            container.Register(Component.For<IControllerFactory>().ImplementedBy<WindsorControllerFactory>());
            
            container.AddFacility<FactorySupportFacility>();

            return container;
        }
    }
}