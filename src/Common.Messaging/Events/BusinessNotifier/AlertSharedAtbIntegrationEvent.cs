using Common.DTO.Notifier.Input;
using Common.DTO.Notifier.Output;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Messaging.Events.BusinessNotifier
{
    public class AlertSharedAtbIntegrationEvent : IntegrationEvent
    {
        [JsonConstructor]
        public AlertSharedAtbIntegrationEvent(ICollection<SharedAtbDto> containers, string generatedByUserId)
     : base(generatedByUserId)
        {
            Payload = new AlertSharedAtbIntegrationEventPayload(containers, generatedByUserId);
        }

        public class AlertSharedAtbIntegrationEventPayload
        {
            [JsonConstructor]
            public AlertSharedAtbIntegrationEventPayload(ICollection<SharedAtbDto> sharedAtbDtos, string user)
            {
                User = user;
                sharedAtbs = sharedAtbDtos;
            }

            [JsonProperty]
            public ICollection<SharedAtbDto> sharedAtbs{ get; set; }

            [JsonProperty]
            public string User { get; set; }
        }
    }
}
