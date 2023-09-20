using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Primitives;

namespace Common.Messaging.ChannelTypes.AzureServiceBus
{
    public interface IServiceBusPersisterConnection : IDisposable
    {
        ITokenProvider TokenProvider { get; }

        ServiceBusConnectionStringBuilder ServiceBusConnectionStringBuilder { get; }

        ITopicClient CreateModel();
    }
}
