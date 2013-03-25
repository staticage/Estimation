using System.Reflection;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Shinetech.PointEstimation.Web.Extensions.Installers
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromAssembly(Assembly.GetExecutingAssembly())
                    .BasedOn<IController>()
                    .Configure(controller =>
                    controller.Named(controller.Implementation.Name.ToLowerInvariant())
                    .LifestyleTransient()),
                Classes.FromAssembly(Assembly.GetExecutingAssembly())
                    .BasedOn<IHttpController>()
                    .Configure(controller =>
                    controller.Named(controller.Implementation.Name.ToLowerInvariant())
                    .LifestyleTransient())
            );
        }
    }
}