using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PSConstruct.DBClasses
{
    public class ConfigContext : DbContext
    {
        
        public DbSet<Config> Configs { get; set; }
        public DbSet<BDMotherBoard> BDMotherBoards { get; set; }
        public DbSet<DBCPU> DBCPUs { get; set; }
        public DbSet<DBGPU> DBGPUs { get; set; }
        public DbSet<DBHDD> DBHDDs { get; set; }
        public DbSet<DBRAM> DBRAMs { get; set; }
        public DbSet<DBPowerUnit> DBPowerUnits { get; set; }
        string connect = "Data Source=config.db";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connect);
        }



    }
}
