using Common.Constants;
using Planning.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Notifier
{
	public class ReportLayerWatersDTO
	{


        public DateTime Dat { get; set; }
        public double? HP { get; set; }
        public double? HR { get; set; }
        public long? ATB { get; set; }
        public double? St { get; set; }
        public double? LSt { get; set; }
        public PlantEnum PlantId { get; set; }
        public ContainerEnum ContainerId { get; set; }
        public WasteEnum WasteId { get; set; }

    }
}
