using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Common;

namespace Planning.Models
{
    public class LogGroup
    {
        public int Id { get; set; }
        public int User { get; set; }
        public int Group { get; set; }
        public ActionGroup Action { get; set; }
        public DateTime Datetime { get; set; }

    }
}
