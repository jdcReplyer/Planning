using Planning.Common;

namespace Common.DTO.Notifier.Input
{
    public class LayerWatersDTO
    {

        public DateTime Dat { get; set; }
        public double? HP { get; set; }
        public double? HR { get; set; }
        public double? St { get; set; }
        public double? LSt { get; set; }
        public PlantEnum PlantId { get; set; }
        public ContainerEnum ContainerId { get; set; }
        public WasteEnum WasteId { get; set; }

    }
}
