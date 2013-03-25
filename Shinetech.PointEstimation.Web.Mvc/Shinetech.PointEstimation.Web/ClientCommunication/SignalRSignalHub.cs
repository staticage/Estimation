using SignalR;

namespace Shinetech.PointEstimation.Web.ClientCommunication
{
    public class SignalRSignalHub : ISignalHub
    {
        public void SendTo<T>(string message) where T : PersistentConnection
        {
            var clients = GlobalHost.ConnectionManager.GetConnectionContext<T>();
            clients.Connection.Broadcast(message);
        }
    }
}