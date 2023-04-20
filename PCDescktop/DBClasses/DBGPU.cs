using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSConstruct.DBClasses
{
    public class DBGPU
    {
        public int DBGPUId { get; set; }
        public string GPUName { get; set; } = string.Empty;
        public string GPUsocket { get; set; } = string.Empty;
        public int GPUMemoryCount { get; set; }
        public string MemoryType { get; set; } = string.Empty;
        public int bandwidth { get; set; }
        public int PowerEat { get; set; }


    }
}
