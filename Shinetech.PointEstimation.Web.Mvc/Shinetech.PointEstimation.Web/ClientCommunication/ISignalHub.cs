using System;
using SignalR;

namespace Shinetech.PointEstimation.Web.ClientCommunication
{
    public interface ISignalHub
    {
        void SendTo<T>(String message)
            where T : PersistentConnection;
    }
}