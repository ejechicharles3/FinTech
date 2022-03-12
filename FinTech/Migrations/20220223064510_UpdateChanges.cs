using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinTech.Migrations
{
    public partial class UpdateChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "ContributionTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContributionTypes",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { 1, 1000m, 1, new DateTime(2022, 2, 20, 18, 54, 18, 693, DateTimeKind.Local).AddTicks(1543), new DateTime(2022, 2, 20, 18, 54, 18, 695, DateTimeKind.Local).AddTicks(4628) });

            migrationBuilder.InsertData(
                table: "Contributions",
                columns: new[] { "Id", "Amount", "ContributionTypeId", "Date", "Time" },
                values: new object[] { 2, 3000m, 2, new DateTime(2022, 2, 20, 18, 54, 18, 695, DateTimeKind.Local).AddTicks(9295), new DateTime(2022, 2, 20, 18, 54, 18, 695, DateTimeKind.Local).AddTicks(9343) });
        }
    }
}
