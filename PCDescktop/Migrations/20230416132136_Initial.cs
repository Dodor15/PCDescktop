using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCDescktop.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BDMotherBoards",
                columns: table => new
                {
                    BDMotherBoardId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MDName = table.Column<string>(type: "TEXT", nullable: false),
                    CPUsocket = table.Column<string>(type: "TEXT", nullable: false),
                    GPUsocket = table.Column<string>(type: "TEXT", nullable: false),
                    RAMsocket = table.Column<string>(type: "TEXT", nullable: false),
                    CountRAM = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BDMotherBoards", x => x.BDMotherBoardId);
                });

            migrationBuilder.CreateTable(
                name: "DBCPUs",
                columns: table => new
                {
                    DBCPUId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CPUName = table.Column<string>(type: "TEXT", nullable: false),
                    CPUsocket = table.Column<string>(type: "TEXT", nullable: false),
                    CoreCount = table.Column<int>(type: "INTEGER", nullable: false),
                    StreamsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CoreHz = table.Column<double>(type: "REAL", nullable: false),
                    GraphicsCore = table.Column<bool>(type: "INTEGER", nullable: false),
                    PowerEat = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBCPUs", x => x.DBCPUId);
                });

            migrationBuilder.CreateTable(
                name: "DBGPUs",
                columns: table => new
                {
                    DBGPUId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GPUName = table.Column<string>(type: "TEXT", nullable: false),
                    GPUsocket = table.Column<string>(type: "TEXT", nullable: false),
                    GPUMemoryCount = table.Column<int>(type: "INTEGER", nullable: false),
                    MemoryType = table.Column<string>(type: "TEXT", nullable: false),
                    bandwidth = table.Column<int>(type: "INTEGER", nullable: false),
                    PowerEat = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBGPUs", x => x.DBGPUId);
                });

            migrationBuilder.CreateTable(
                name: "DBHDDs",
                columns: table => new
                {
                    DBHDDId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HDDName = table.Column<string>(type: "TEXT", nullable: false),
                    HDDMemoryCount = table.Column<int>(type: "INTEGER", nullable: false),
                    MemorySpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    HDDPowerEat = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBHDDs", x => x.DBHDDId);
                });

            migrationBuilder.CreateTable(
                name: "DBPowerUnits",
                columns: table => new
                {
                    DBPowerUnitId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PowerUnitName = table.Column<string>(type: "TEXT", nullable: false),
                    Power = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBPowerUnits", x => x.DBPowerUnitId);
                });

            migrationBuilder.CreateTable(
                name: "DBRAMs",
                columns: table => new
                {
                    DBRAMId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RAMName = table.Column<string>(type: "TEXT", nullable: false),
                    RamMemoryCount = table.Column<int>(type: "INTEGER", nullable: false),
                    RamMemorySpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    RAMsocket = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBRAMs", x => x.DBRAMId);
                });

            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    ConfigId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConfigName = table.Column<string>(type: "TEXT", nullable: false),
                    BDMotherBoardsBDMotherBoardId = table.Column<int>(type: "INTEGER", nullable: true),
                    DBCPUsDBCPUId = table.Column<int>(type: "INTEGER", nullable: true),
                    DBGPUsDBGPUId = table.Column<int>(type: "INTEGER", nullable: true),
                    DBHDDsDBHDDId = table.Column<int>(type: "INTEGER", nullable: true),
                    DBRAMsDBRAMId = table.Column<int>(type: "INTEGER", nullable: true),
                    DBPowerUnitsDBPowerUnitId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.ConfigId);
                    table.ForeignKey(
                        name: "FK_Configs_BDMotherBoards_BDMotherBoardsBDMotherBoardId",
                        column: x => x.BDMotherBoardsBDMotherBoardId,
                        principalTable: "BDMotherBoards",
                        principalColumn: "BDMotherBoardId");
                    table.ForeignKey(
                        name: "FK_Configs_DBCPUs_DBCPUsDBCPUId",
                        column: x => x.DBCPUsDBCPUId,
                        principalTable: "DBCPUs",
                        principalColumn: "DBCPUId");
                    table.ForeignKey(
                        name: "FK_Configs_DBGPUs_DBGPUsDBGPUId",
                        column: x => x.DBGPUsDBGPUId,
                        principalTable: "DBGPUs",
                        principalColumn: "DBGPUId");
                    table.ForeignKey(
                        name: "FK_Configs_DBHDDs_DBHDDsDBHDDId",
                        column: x => x.DBHDDsDBHDDId,
                        principalTable: "DBHDDs",
                        principalColumn: "DBHDDId");
                    table.ForeignKey(
                        name: "FK_Configs_DBPowerUnits_DBPowerUnitsDBPowerUnitId",
                        column: x => x.DBPowerUnitsDBPowerUnitId,
                        principalTable: "DBPowerUnits",
                        principalColumn: "DBPowerUnitId");
                    table.ForeignKey(
                        name: "FK_Configs_DBRAMs_DBRAMsDBRAMId",
                        column: x => x.DBRAMsDBRAMId,
                        principalTable: "DBRAMs",
                        principalColumn: "DBRAMId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configs_BDMotherBoardsBDMotherBoardId",
                table: "Configs",
                column: "BDMotherBoardsBDMotherBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Configs_DBCPUsDBCPUId",
                table: "Configs",
                column: "DBCPUsDBCPUId");

            migrationBuilder.CreateIndex(
                name: "IX_Configs_DBGPUsDBGPUId",
                table: "Configs",
                column: "DBGPUsDBGPUId");

            migrationBuilder.CreateIndex(
                name: "IX_Configs_DBHDDsDBHDDId",
                table: "Configs",
                column: "DBHDDsDBHDDId");

            migrationBuilder.CreateIndex(
                name: "IX_Configs_DBPowerUnitsDBPowerUnitId",
                table: "Configs",
                column: "DBPowerUnitsDBPowerUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Configs_DBRAMsDBRAMId",
                table: "Configs",
                column: "DBRAMsDBRAMId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "BDMotherBoards");

            migrationBuilder.DropTable(
                name: "DBCPUs");

            migrationBuilder.DropTable(
                name: "DBGPUs");

            migrationBuilder.DropTable(
                name: "DBHDDs");

            migrationBuilder.DropTable(
                name: "DBPowerUnits");

            migrationBuilder.DropTable(
                name: "DBRAMs");
        }
    }
}
