using Planning.Common;

namespace Common.DTO.Notifier.Output
{
    public class ContainerDTO
    {
        public ContainerEnum Container { get; set; }
        public PlantEnum Plant { get; set; }
        public WasteEnum WastesId { get; set; }
        public long? MinLevel { get; set; }
        public long? MaxLevel { get; set; }
        public long? MinAlert { get; set; }
        public long? MaxAlert { get; set; }
    }
}
