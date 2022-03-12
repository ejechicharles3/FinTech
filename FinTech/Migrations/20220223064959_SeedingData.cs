using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinTech.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContributionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Savings" });

            migrationBuilder.InsertData(
                table: "ContributionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "End-Well" });

            migrationBuilder.InsertData(
                table: "Contributions",
                columns: new[] { "Id", "Amount", "ContributionTypeId", "Date", "Time" },
                values: new object[,]
                {
                    { 1, 1000m, 1, new DateTime(2022, 2, 23, 7, 49, 58, 899, DateTimeKind.Local).AddTicks(9086), new DateTime(2022, 2, 23, 7, 49, 58, 901, DateTimeKind.Local).AddTicks(2326) },
                    { 3, 3000m, 1, new DateTime(2022, 2, 23, 7, 49, 58, 901, DateTimeKind.Local).AddTicks(3954), new DateTime(2022, 2, 23, 7, 49, 58, 901, DateTimeKind.Local).AddTicks(3955) },
                    { 2, 3000m, 2, new DateTime(2022, 2, 23, 7, 49, 58, 901, DateTimeKind.Local).AddTicks(3942), new DateTime(2022, 2, 23, 7, 49, 58, 901, DateTimeKind.Local).AddTicks(3950) },
                    { 4, 6000m, 2, new DateTime(2022, 2, 23, 7, 49, 58, 901, DateTimeKind.Local).AddTicks(3958), new DateTime(2022, 2, 23, 7, 49, 58, 901, DateTimeKind.Local).AddTicks(3959) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contributions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contributions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contributions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contributions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ContributionTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContributionTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
