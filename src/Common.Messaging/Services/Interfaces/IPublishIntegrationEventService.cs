using Common.DTO.Notifier.Input;
using Common.DTO.Notifier.Output;

namespace Common.Messaging.Services.Interfaces
{
    public interface IPublishIntegrationEventService
    {
        Task PublishContainersWarningsIntegrationEvent(ICollection<WarningsDTO> warnings, string user);
        Task PublishSharedATBIntegrationEvent(ICollection<SharedAtbDto> sharedATBs, string user);
        Task PublishSharedATBTakeInChargeIntegrationEvent(SharedAtbTakeInChargeDto takeInCharge, string user);
    }
}