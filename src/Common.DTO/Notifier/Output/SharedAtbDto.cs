using Planning.Common;

namespace Common.DTO.Notifier.Output
{
    public class SharedAtbDto
    {
        public ContainerEnum containerID { get; init; }
        public PlantEnum PlantId { get; init; }
        public WasteEnum WasteId { get; init; }
        public List<DateTime> Days { get; init; }
        public string User { get; set; }
    }
}
