// <auto-generated />
using System;
using FinTech.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinTech.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220223064959_SeedingData")]
    partial class SeedingData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("FinTech.Data.Contribution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ContributionTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContributionTypeId");

                    b.ToTable("Contributions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 1000m,
                            ContributionTypeId = 1,
                            Date = new DateTime(2022, 2, 23, 7, 49, 58, 899, DateTimeKind.Local).AddTicks(9086),
                            Time = new DateTime(2022, 2, 23, 7, 49, 58, 901, DateTimeKind.Local).AddTicks(2326)
                        },
                        new
                        {
                            Id = 2,
                            Amount = 3000m,
                            ContributionTypeId = 2,
                            Date = new DateTime(2022, 2, 23, 7, 49, 58, 901, DateTimeKind.Local).AddTicks(3942),
                            Time = new DateTime(2022, 2, 23, 7, 49, 58, 901, DateTimeKind.Local).AddTicks(3950)
                        },
                        new
                        {
                            Id = 3,
                            Amount = 3000m,
                            ContributionTypeId = 1,
                            Date = new DateTime(2022, 2, 23, 7, 49, 58, 901, DateTimeKind.Local).AddTicks(3954),
                            Time = new DateTime(2022, 2, 23, 7, 49, 58, 901, DateTimeKind.Local).AddTicks(3955)
                        },
                        new
                        {
                            Id = 4,
                            Amount = 6000m,
                            ContributionTypeId = 2,
                            Date = new DateTime(2022, 2, 23, 7, 49, 58, 901, DateTimeKind.Local).AddTicks(3958),
                            Time = new DateTime(2022, 2, 23, 7, 49, 58, 901, DateTimeKind.Local).AddTicks(3959)
                        });
                });

            modelBuilder.Entity("FinTech.Data.ContributionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContributionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Savings"
                        },
                        new
                        {
                            Id = 2,
                            Name = "End-Well"
                        });
                });

            modelBuilder.Entity("FinTech.Data.Contribution", b =>
                {
                    b.HasOne("FinTech.Data.ContributionType", "ContributionType")
                        .WithMany("Contributions")
                        .HasForeignKey("ContributionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContributionType");
                });

            modelBuilder.Entity("FinTech.Data.ContributionType", b =>
                {
                    b.Navigation("Contributions");
                });
#pragma warning restore 612, 618
        }
    }
}
