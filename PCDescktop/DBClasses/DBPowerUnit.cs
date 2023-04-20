using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSConstruct.DBClasses
{
    public class DBPowerUnit
    {
        public int DBPowerUnitId { get; set; }
        public string PowerUnitName { get; set; } = string.Empty;
        public int Power { get; set; }
    }
}
