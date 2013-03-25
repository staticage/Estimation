using System;
using System.IO;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Shinetech.PointEstimation.Web.App_Start;
using Shinetech.PointEstimation.Web.ClientCommunication;
using Shinetech.PointEstimation.Web.Extensions;
using Shinetech.PointEstimation.Web.Mvc;
using Shinetech.PointEstimation.Web.Mvc.Extensions;
using SignalR;

namespace Shinetech.PointEstimation.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.MapConnection<ClientSignalConnection>("status", "status/{*operation}");
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AreaRegistration.RegisterAllAreas();

            var container = WindsorContainerBootstrapper.Bootstrap();
            ControllerBuilder.Current.SetControllerFactory(container.Resolve<IControllerFactory>());

            using (var stream = File.Open(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.cfg.xml"), FileMode.Open))
            {
                log4net.Config.XmlConfigurator.Configure(stream);
            }
            var httpDependencyResolver = new WindsorHttpDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = httpDependencyResolver;

        }
    }
}