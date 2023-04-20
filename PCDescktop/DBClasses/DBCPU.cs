using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSConstruct.DBClasses
{
    public class DBCPU
    {
        public int DBCPUId { get; set; }
        public string CPUName { get; set; } = string.Empty;
        public string CPUsocket { get; set; } = string.Empty;
        public int CoreCount { get; set; }
        public int StreamsCount { get; set; }
        public double CoreHz { get; set; }
        public bool GraphicsCore { get; set; }
        public int PowerEat { get; set; }

    }
}
