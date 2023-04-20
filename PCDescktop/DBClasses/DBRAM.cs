using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSConstruct.DBClasses
{
    public class DBRAM
    {
        public int DBRAMId { get; set; }
        public string RAMName { get; set; } = string.Empty;
        public int RamMemoryCount { get; set; }
        public int RamMemorySpeed { get; set; }
        public string RAMsocket { get; set; } = string.Empty;
    }
}
