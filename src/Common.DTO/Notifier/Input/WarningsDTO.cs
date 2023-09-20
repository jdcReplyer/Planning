using Planning.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Notifier.Input
{
    public class WarningsDTO
    {
        public int? Id { get; private set; }
        public ContainerEnum ContainerId { get; private set; }
        public PlantEnum PlantId { get; private set; }
        public WasteEnum WastId { get; private set; }
        public DateTime Date { get; private set; }
        public WarningType WarningType { get; private set; }

    }
}
