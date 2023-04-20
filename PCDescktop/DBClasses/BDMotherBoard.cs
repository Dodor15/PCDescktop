using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSConstruct.DBClasses
{
    public class BDMotherBoard
    {
        public int BDMotherBoardId { get; set; }
        public string MDName { get; set; } = string.Empty;
        public string CPUsocket { get; set; } = string.Empty;
        public string GPUsocket { get; set; } = string.Empty;
        public string RAMsocket { get; set; } = string.Empty;
        public int CountRAM { get; set; }
        
    }
}
