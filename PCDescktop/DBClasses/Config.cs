using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PSConstruct.DBClasses
{
    public class Config
    {
        public int ConfigId { get; set; }
        public string ConfigName { get; set; } = string.Empty;
        public BDMotherBoard? BDMotherBoards { get; set; }
        public DBCPU? DBCPUs { get; set; }
        public DBGPU? DBGPUs { get; set; }
        public DBHDD? DBHDDs { get; set; }
        public DBRAM? DBRAMs { get; set; }
        public DBPowerUnit? DBPowerUnits { get; set; }


    }
}
