using Newtonsoft.Json;

namespace Common.Messaging.Events.BusinessNotifier
{
    public class AlertGeneratedIntegrationEvent : IntegrationEvent
    {
        [JsonConstructor]
        public AlertGeneratedIntegrationEvent(string alertType, long subsidiaryId, string user)
            : base(user)
        {
            Payload = new AlertGeneratedIntegrationEventPayload(alertType, subsidiaryId, user);
        }
    }

    public class AlertGeneratedIntegrationEventPayload
    {
        [JsonConstructor]
        public AlertGeneratedIntegrationEventPayload(string alertType, long subsidiaryId, string user)
        {
            AlertType = alertType;
            SubsidiaryId = subsidiaryId;

            User = user;
        }

        [JsonProperty]
        public string AlertType { get; set; }

        [JsonProperty]
        public long SubsidiaryId { get; set; }

        [JsonProperty]
        public string User { get; set; }
    }
}
