using Common.DTO.Notifier.Output;
using Newtonsoft.Json;

namespace Common.Messaging.Events.BusinessNotifier
{

    public class ActionOnContainerIntegrationEvent : IntegrationEvent
    {
        [JsonConstructor]
        public ActionOnContainerIntegrationEvent(ICollection<ContainerDTO> containers, string generatedByUserId)
            : base(generatedByUserId)
        {
            Payload = new ActionOnContainerIntegrationEventPayload(containers, generatedByUserId);
        }
    }

    public class ActionOnContainerIntegrationEventPayload
    {
        [JsonConstructor]
        public ActionOnContainerIntegrationEventPayload(ICollection<ContainerDTO> containers, string user)
        {
            User = user;
            Containers = containers;
        }

        [JsonProperty]
        public ICollection<ContainerDTO> Containers { get; set; }

        [JsonProperty]
        public string User { get; set; }
    }
}
