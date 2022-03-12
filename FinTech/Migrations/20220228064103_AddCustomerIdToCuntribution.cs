using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinTech.Migrations
{
    public partial class AddCustomerIdToCuntribution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e2d2133-6ffa-436b-805a-a0f78ed4ba71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2759a57c-d945-40f2-a7f7-e72eb4f924b2");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Contributions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d972d402-40d6-4648-92d1-b35807fd40b5", "f37581a8-c1ff-4fda-a9b8-b28734de572f", "User", "USER" },
                    { "eb67ac4d-1c00-49b6-a5da-1fa5210ef3ca", "b2f5dd71-24ac-4cfa-8c4e-abe890318861", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Contributions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2022, 2, 28, 7, 41, 2, 97, DateTimeKind.Local).AddTicks(5132), new DateTime(2022, 2, 28, 7, 41, 2, 99, DateTimeKind.Local).AddTicks(6223) });

            migrationBuilder.UpdateData(
                table: "Contributions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2022, 2, 28, 7, 41, 2, 99, DateTimeKind.Local).AddTicks(9103), new DateTime(2022, 2, 28, 7, 41, 2, 99, DateTimeKind.Local).AddTicks(9118) });

            migrationBuilder.UpdateData(
                table: "Contributions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2022, 2, 28, 7, 41, 2, 99, DateTimeKind.Local).AddTicks(9123), new DateTime(2022, 2, 28, 7, 41, 2, 99, DateTimeKind.Local).AddTicks(9125) });

            migrationBuilder.UpdateData(
                table: "Contributions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2022, 2, 28, 7, 41, 2, 99, DateTimeKind.Local).AddTicks(9128), new DateTime(2022, 2, 28, 7, 41, 2, 99, DateTimeKind.Local).AddTicks(9130) });

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_CustomerId",
                table: "Contributions",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_AspNetUsers_CustomerId",
                table: "Contributions",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_AspNetUsers_CustomerId",
                table: "Contributions");

            migrationBuilder.DropIndex(
                name: "IX_Contributions_CustomerId",
                table: "Contributions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d972d402-40d6-4648-92d1-b35807fd40b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb67ac4d-1c00-49b6-a5da-1fa5210ef3ca");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Contributions");

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
    }
}
