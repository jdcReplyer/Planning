using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Primitives;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Logging;

namespace Common.Messaging.ChannelTypes.AzureServiceBus
{
    public class DefaultServiceBusPersisterConnection : IServiceBusPersisterConnection
    {
        private readonly ILogger<DefaultServiceBusPersisterConnection> _logger;
        private readonly ServiceBusConnectionStringBuilder _serviceBusConnectionStringBuilder;
        private readonly ITokenProvider _tokenProvider;
        private ITopicClient _topicClient;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _tenantId;

        bool _disposed;

        public DefaultServiceBusPersisterConnection(ServiceBusConnectionStringBuilder serviceBusConnectionStringBuilder,
            string clientId,
            string clientSecret,
            string tenantId,
            ILogger<DefaultServiceBusPersisterConnection> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _serviceBusConnectionStringBuilder = serviceBusConnectionStringBuilder ??
                throw new ArgumentNullException(nameof(serviceBusConnectionStringBuilder));

            _clientId = clientId;
            _clientSecret = clientSecret;
            _tenantId = tenantId;

            try
            {
                _tokenProvider = new Microsoft.Azure.ServiceBus.Primitives.ManagedIdentityTokenProvider(
                    new AzureServiceTokenProvider($"RunAs=App;AppId={_clientId};TenantId={_tenantId};AppKey={_clientSecret}"));
                _topicClient = new TopicClient(
                    _serviceBusConnectionStringBuilder.Endpoint,
                    _serviceBusConnectionStringBuilder.EntityPath,
                    _tokenProvider,
                    retryPolicy: RetryPolicy.Default);

                _topicClient.OperationTimeout = TimeSpan.FromMinutes(5);
            }
            catch (Exception ex)
            {
                var e = ex;
            }
        }

        public ServiceBusConnectionStringBuilder ServiceBusConnectionStringBuilder => _serviceBusConnectionStringBuilder;
        public ITokenProvider TokenProvider => _tokenProvider;

        public ITopicClient CreateModel()
        {
            if (_topicClient.IsClosedOrClosing)
            {
                var tokenProvider = new Microsoft.Azure.ServiceBus.Primitives.ManagedIdentityTokenProvider(
                    new AzureServiceTokenProvider($"RunAs=App;AppId={_clientId};TenantId={_tenantId};AppKey={_clientSecret}"));
                _topicClient = new TopicClient(
                    _serviceBusConnectionStringBuilder.Endpoint,
                    _serviceBusConnectionStringBuilder.EntityPath,
                    tokenProvider,
                    retryPolicy: RetryPolicy.Default);

                _topicClient.OperationTimeout = TimeSpan.FromMinutes(5);
            }

            return _topicClient;
        }

        public void Dispose()
        {
            if (_disposed) return;

            _disposed = true;
        }
    }
}
