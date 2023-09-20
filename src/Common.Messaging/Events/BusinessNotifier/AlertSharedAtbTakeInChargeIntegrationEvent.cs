using Common.DTO.Notifier.Output;
using Newtonsoft.Json;

namespace Common.Messaging.Events.BusinessNotifier
{
    public class AlertSharedAtbTakeInChargeIntegrationEvent : IntegrationEvent
    {
        [JsonConstructor]
        public AlertSharedAtbTakeInChargeIntegrationEvent(SharedAtbTakeInChargeDto sharedAtbsTakeInCharge, string generatedByUserId)
     : base(generatedByUserId)
        {
            Payload = new AlertSharedAtbTakeInChargeIntegrationEventPayload(sharedAtbsTakeInCharge, generatedByUserId);
        }

        public class AlertSharedAtbTakeInChargeIntegrationEventPayload
        {
            [JsonConstructor]
            public AlertSharedAtbTakeInChargeIntegrationEventPayload(SharedAtbTakeInChargeDto sharedAtbsTakeInChargeInput, string user)
            {
                User = user;
                sharedAtbsTakeInCharge = sharedAtbsTakeInChargeInput;
            }

            [JsonProperty]
            public SharedAtbTakeInChargeDto sharedAtbsTakeInCharge{ get; set; }

            [JsonProperty]
            public string User { get; set; }
        }
    }
}
