﻿// <auto-generated />
using System;
using Haiyue.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Haiyue.EF.Migrations
{
    [DbContext(typeof(HYContext))]
    [Migration("20181227033752_UpdateUserTable1")]
    partial class UpdateUserTable1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Haiyue.Model.Model.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<double>("ExchangeRate");

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Currencys");
                });

            modelBuilder.Entity("Haiyue.Model.Model.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Haiyue.Model.Model.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Haiyue.Model.Model.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<int>("CurrencyId");

                    b.Property<int>("GameId");

                    b.Property<string>("Handler");

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<int>("Number");

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("OrderNumber");

                    b.Property<string>("PaymentAccount");

                    b.Property<int>("PaymentStatus");

                    b.Property<double>("RealIncome");

                    b.Property<double>("RealIncomeRMB");

                    b.Property<string>("Remarks");

                    b.Property<string>("ServerName");

                    b.Property<string>("SupplierPhone");

                    b.Property<int>("TotalNumber");

                    b.Property<double>("TotalPrice");

                    b.Property<double>("UnitPrice");

                    b.HasKey("Id");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Haiyue.Model.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<int>("Education");

                    b.Property<DateTime>("EntryTime");

                    b.Property<string>("IdNumber");

                    b.Property<int>("IncumbencyStatus");

                    b.Property<string>("JobNumber");

                    b.Property<int>("Jurisdiction");

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("LoginTime");

                    b.Property<string>("Name");

                    b.Property<string>("PassWored");

                    b.Property<string>("Phone");

                    b.Property<int>("PositionId");

                    b.Property<string>("RegisteredResidence");

                    b.Property<string>("Remarks");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Haiyue.Model.Model.User", b =>
                {
                    b.HasOne("Haiyue.Model.Model.Position")
                        .WithMany("User")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
