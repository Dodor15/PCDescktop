﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PSConstruct.DBClasses;

#nullable disable

namespace PCDescktop.Migrations
{
    [DbContext(typeof(ConfigContext))]
    [Migration("20230416132136_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("PSConstruct.DBClasses.BDMotherBoard", b =>
                {
                    b.Property<int>("BDMotherBoardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPUsocket")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CountRAM")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GPUsocket")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MDName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RAMsocket")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BDMotherBoardId");

                    b.ToTable("BDMotherBoards");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.Config", b =>
                {
                    b.Property<int>("ConfigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BDMotherBoardsBDMotherBoardId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConfigName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("DBCPUsDBCPUId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DBGPUsDBGPUId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DBHDDsDBHDDId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DBPowerUnitsDBPowerUnitId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DBRAMsDBRAMId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ConfigId");

                    b.HasIndex("BDMotherBoardsBDMotherBoardId");

                    b.HasIndex("DBCPUsDBCPUId");

                    b.HasIndex("DBGPUsDBGPUId");

                    b.HasIndex("DBHDDsDBHDDId");

                    b.HasIndex("DBPowerUnitsDBPowerUnitId");

                    b.HasIndex("DBRAMsDBRAMId");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.DBCPU", b =>
                {
                    b.Property<int>("DBCPUId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPUName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CPUsocket")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CoreCount")
                        .HasColumnType("INTEGER");

                    b.Property<double>("CoreHz")
                        .HasColumnType("REAL");

                    b.Property<bool>("GraphicsCore")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PowerEat")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StreamsCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("DBCPUId");

                    b.ToTable("DBCPUs");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.DBGPU", b =>
                {
                    b.Property<int>("DBGPUId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GPUMemoryCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GPUName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GPUsocket")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MemoryType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PowerEat")
                        .HasColumnType("INTEGER");

                    b.Property<int>("bandwidth")
                        .HasColumnType("INTEGER");

                    b.HasKey("DBGPUId");

                    b.ToTable("DBGPUs");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.DBHDD", b =>
                {
                    b.Property<int>("DBHDDId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HDDMemoryCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HDDName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HDDPowerEat")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MemorySpeed")
                        .HasColumnType("INTEGER");

                    b.HasKey("DBHDDId");

                    b.ToTable("DBHDDs");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.DBPowerUnit", b =>
                {
                    b.Property<int>("DBPowerUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Power")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PowerUnitName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DBPowerUnitId");

                    b.ToTable("DBPowerUnits");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.DBRAM", b =>
                {
                    b.Property<int>("DBRAMId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RAMName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RAMsocket")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RamMemoryCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RamMemorySpeed")
                        .HasColumnType("INTEGER");

                    b.HasKey("DBRAMId");

                    b.ToTable("DBRAMs");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.Config", b =>
                {
                    b.HasOne("PSConstruct.DBClasses.BDMotherBoard", "BDMotherBoards")
                        .WithMany()
                        .HasForeignKey("BDMotherBoardsBDMotherBoardId");

                    b.HasOne("PSConstruct.DBClasses.DBCPU", "DBCPUs")
                        .WithMany()
                        .HasForeignKey("DBCPUsDBCPUId");

                    b.HasOne("PSConstruct.DBClasses.DBGPU", "DBGPUs")
                        .WithMany()
                        .HasForeignKey("DBGPUsDBGPUId");

                    b.HasOne("PSConstruct.DBClasses.DBHDD", "DBHDDs")
                        .WithMany()
                        .HasForeignKey("DBHDDsDBHDDId");

                    b.HasOne("PSConstruct.DBClasses.DBPowerUnit", "DBPowerUnits")
                        .WithMany()
                        .HasForeignKey("DBPowerUnitsDBPowerUnitId");

                    b.HasOne("PSConstruct.DBClasses.DBRAM", "DBRAMs")
                        .WithMany()
                        .HasForeignKey("DBRAMsDBRAMId");

                    b.Navigation("BDMotherBoards");

                    b.Navigation("DBCPUs");

                    b.Navigation("DBGPUs");

                    b.Navigation("DBHDDs");

                    b.Navigation("DBPowerUnits");

                    b.Navigation("DBRAMs");
                });
#pragma warning restore 612, 618
        }
    }
}
