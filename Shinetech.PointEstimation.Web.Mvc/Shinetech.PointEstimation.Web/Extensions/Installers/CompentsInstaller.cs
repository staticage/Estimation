using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Shinetech.PointEstimation.Web.ClientCommunication;

namespace Shinetech.PointEstimation.Web.Extensions.Installers
{
    public class CompentsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ISignalHub>()
                    .ImplementedBy<SignalRSignalHub>()
            );
        }
    }
}