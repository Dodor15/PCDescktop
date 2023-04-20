using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSConstruct.DBClasses
{
    public class DBHDD
    {
        public int DBHDDId { get; set; }
        public string HDDName { get; set; } = string.Empty;
        public int HDDMemoryCount { get; set; }
        public int MemorySpeed { get; set; }
        public int HDDPowerEat { get; set; }
    }
}
