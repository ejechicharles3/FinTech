using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinTech.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e2d2133-6ffa-436b-805a-a0f78ed4ba71", "e06480b1-1cbb-4490-988a-8fa01eedca7b", "User", "USER" },
                    { "2759a57c-d945-40f2-a7f7-e72eb4f924b2", "b5d53019-58f9-438c-9173-2e566ecb47d6", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Contributions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2022, 2, 26, 7, 7, 48, 876, DateTimeKind.Local).AddTicks(7046), new DateTime(2022, 2, 26, 7, 7, 48, 905, DateTimeKind.Local).AddTicks(5181) });

            migrationBuilder.UpdateData(
                table: "Contributions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2022, 2, 26, 7, 7, 48, 906, DateTimeKind.Local).AddTicks(1628), new DateTime(2022, 2, 26, 7, 7, 48, 906, DateTimeKind.Local).AddTicks(1662) });

            migrationBuilder.UpdateData(
                table: "Contributions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2022, 2, 26, 7, 7, 48, 906, DateTimeKind.Local).AddTicks(1676), new DateTime(2022, 2, 26, 7, 7, 48, 906, DateTimeKind.Local).AddTicks(1682) });

            migrationBuilder.UpdateData(
                table: "Contributions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2022, 2, 26, 7, 7, 48, 906, DateTimeKind.Local).AddTicks(1689), new DateTime(2022, 2, 26, 7, 7, 48, 906, DateTimeKind.Local).AddTicks(1695) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e2d2133-6ffa-436b-805a-a0f78ed4ba71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2759a57c-d945-40f2-a7f7-e72eb4f924b2");

            migrationBuilder.UpdateData(
                table: "Contributions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2022, 2, 24, 22, 37, 2, 215, DateTimeKind.Local).AddTicks(1151), new DateTime(2022, 2, 24, 22, 37, 2, 216, DateTimeKind.Local).AddTicks(5992) });

            migrationBuilder.UpdateData(
                table: "Contributions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2022, 2, 24, 22, 37, 2, 216, DateTimeKind.Local).AddTicks(7776), new DateTime(2022, 2, 24, 22, 37, 2, 216, DateTimeKind.Local).AddTicks(7785) });

            migrationBuilder.UpdateData(
                table: "Contributions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2022, 2, 24, 22, 37, 2, 216, DateTimeKind.Local).AddTicks(7789), new DateTime(2022, 2, 24, 22, 37, 2, 216, DateTimeKind.Local).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "Contributions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2022, 2, 24, 22, 37, 2, 216, DateTimeKind.Local).AddTicks(7793), new DateTime(2022, 2, 24, 22, 37, 2, 216, DateTimeKind.Local).AddTicks(7794) });
        }
    }
}
