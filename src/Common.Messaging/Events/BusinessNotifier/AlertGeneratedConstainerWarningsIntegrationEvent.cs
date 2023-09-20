using Common.DTO.Notifier.Input;
using Newtonsoft.Json;

namespace Common.Messaging.Events.BusinessNotifier
{
    public class AlertGeneratedConstainerWarningsIntegrationEvent : IntegrationEvent
    {
        [JsonConstructor]
        public AlertGeneratedConstainerWarningsIntegrationEvent(ICollection<WarningsDTO> containers, string generatedByUserId)
         : base(generatedByUserId)
        {
            Payload = new AlertGeneratedConstainerWarningsIntegrationEventPayload(containers, generatedByUserId);
        }

        public class AlertGeneratedConstainerWarningsIntegrationEventPayload
        {
            [JsonConstructor]
            public AlertGeneratedConstainerWarningsIntegrationEventPayload(ICollection<WarningsDTO> containers, string user)
            {
                User = user;
                ContainerWarnings = containers;
            }

            [JsonProperty]
            public ICollection<WarningsDTO> ContainerWarnings { get; set; }

            [JsonProperty]
            public string User { get; set; }
        }
    }
}
