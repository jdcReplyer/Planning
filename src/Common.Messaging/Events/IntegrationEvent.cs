using Newtonsoft.Json;

namespace Common.Messaging.Events
{
    public abstract class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        public IntegrationEvent(string generatedByUserId) : this()
        {
            GeneratedByUserId = generatedByUserId;
        }

        public IntegrationEvent(string generatedByUserId, string energySystemCode) : this()
        {
            GeneratedByUserId = generatedByUserId;
            EnergySystemCode = energySystemCode;
        }

        public IntegrationEvent(Guid? id, string generatedByUserId, string energySystemCode) : this()
        {
            if (id.HasValue)
                Id = id.Value;
            else
                Id = Guid.NewGuid();

            CreationDate = DateTime.UtcNow;
            GeneratedByUserId = generatedByUserId;
            EnergySystemCode = energySystemCode;
        }

        [JsonConstructor]
        public IntegrationEvent(Guid id, DateTime createDate, string generatedByUserId, string energySystemCode)
        {
            Id = id;
            CreationDate = createDate;
            GeneratedByUserId = generatedByUserId;
            EnergySystemCode = energySystemCode;
        }

        // A unique identified for the event
        [JsonProperty]
        public Guid Id { get; private set; }

        // A unique identified for the message on Bus
        [JsonProperty]
        public Guid MessageId { get; set; }

        // Creation date of the event
        [JsonProperty]
        public DateTime CreationDate { get; private set; }

        // User that generated the event
        [JsonProperty]
        public string GeneratedByUserId { get; private set; }

        // Energy System Code
        [JsonProperty]
        public string EnergySystemCode { get; private set; }

        // An object containing specific information of the event.
        // This has to be implemented in the child classes.
        [JsonProperty]
        public object Payload { get; set; }
    }
}
