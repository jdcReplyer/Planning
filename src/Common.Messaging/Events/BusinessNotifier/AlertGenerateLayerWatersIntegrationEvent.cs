using Common.DTO.Notifier;
using Common.DTO.Notifier.Input;
using Newtonsoft.Json;

namespace Common.Messaging.Events.BusinessNotifier
{
    public class AlertGenerateLayerWatersIntegrationEvent : IntegrationEvent
    {
        [JsonConstructor]
        public AlertGenerateLayerWatersIntegrationEvent(List<ReportLayerWatersDTO> historicizationLayersWaters, ReportDTO report, string user)
            : base(user)
        {
            Payload = new AlertGenerateLayerWatersPayload(historicizationLayersWaters, report, user);
        }
    }

    public class AlertGenerateLayerWatersPayload
    {
        [JsonConstructor]
        public AlertGenerateLayerWatersPayload(List<ReportLayerWatersDTO> historicizationLayersWaters, ReportDTO report, string user = "")
        {
            HistoricizationLayersWaters = historicizationLayersWaters;
            Report = report;
            User = user;
        }

        [JsonProperty]
        public List<ReportLayerWatersDTO> HistoricizationLayersWaters { get; set; }

        [JsonProperty]
        public ReportDTO Report { get; set; }

        [JsonProperty]
        public string User { get; set; }
    }
}
