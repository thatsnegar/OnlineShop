using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Adddisplayordertoquestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SequenceNumbers",
                keyColumn: "Id",
                keyValue: new Guid("94a90159-e01e-42b8-b66d-3815e572d2bd"));

            migrationBuilder.DeleteData(
                table: "SequenceNumbers",
                keyColumn: "Id",
                keyValue: new Guid("dda43014-f90a-4a82-ba04-93da0bc7e5c6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b50df749-fff2-4a7c-afb4-f22a4e0afc50"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("81babea2-1f23-4b88-b607-693fa9ea2cfb"));

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Questions",
                newName: "DisplayOrder");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "UpdateDateTime" },
                values: new object[] { new Guid("0a8d35e3-14b9-4cc2-a0c9-9b8fbe8d650a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 7, 16, 47, 40, 833, DateTimeKind.Local).AddTicks(3906), false, "Developer", new DateTime(2023, 1, 7, 16, 47, 40, 833, DateTimeKind.Local).AddTicks(3940) });

            migrationBuilder.InsertData(
                table: "SequenceNumbers",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "Number", "UpdateDateTime" },
                values: new object[] { new Guid("469137d5-93ca-4ec4-ac78-5045340ee420"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 7, 16, 47, 40, 833, DateTimeKind.Local).AddTicks(4494), false, "TracingCode", 1, new DateTime(2023, 1, 7, 16, 47, 40, 833, DateTimeKind.Local).AddTicks(4498) });

            migrationBuilder.InsertData(
                table: "SequenceNumbers",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "Number", "UpdateDateTime" },
                values: new object[] { new Guid("f722bbed-d807-4ff2-8f0c-43d5874b677d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 7, 16, 47, 40, 833, DateTimeKind.Local).AddTicks(4523), false, "RegisterDiscount", 1, new DateTime(2023, 1, 7, 16, 47, 40, 833, DateTimeKind.Local).AddTicks(4525) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActivationCode", "BirthDate", "CellPhoneNumber", "DeleteDateTime", "EmailAddress", "Especialty", "FirstName", "FullName", "Gender", "InsertDateTime", "IsActive", "IsEdited", "LastName", "MENumber", "NationalCode", "OfficeAddress", "Password", "PhoneNumber", "RoleId", "UpdateDateTime", "Username" },
                values: new object[] { new Guid("b490fecd-7738-40b6-9087-cf98d4dc92a3"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@fidarafzar.ir", null, null, null, 2, new DateTime(2023, 1, 7, 16, 47, 40, 833, DateTimeKind.Local).AddTicks(4149), true, false, null, null, null, null, "069d28fa7cad5da31006c8a765c831a69ac1866ff32fae5ef3f9c8ae19118b86", null, new Guid("0a8d35e3-14b9-4cc2-a0c9-9b8fbe8d650a"), new DateTime(2023, 1, 7, 16, 47, 40, 833, DateTimeKind.Local).AddTicks(4152), "developer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SequenceNumbers",
                keyColumn: "Id",
                keyValue: new Guid("469137d5-93ca-4ec4-ac78-5045340ee420"));

            migrationBuilder.DeleteData(
                table: "SequenceNumbers",
                keyColumn: "Id",
                keyValue: new Guid("f722bbed-d807-4ff2-8f0c-43d5874b677d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b490fecd-7738-40b6-9087-cf98d4dc92a3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0a8d35e3-14b9-4cc2-a0c9-9b8fbe8d650a"));

            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Questions",
                newName: "Number");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "UpdateDateTime" },
                values: new object[] { new Guid("81babea2-1f23-4b88-b607-693fa9ea2cfb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 24, 12, 14, 12, 937, DateTimeKind.Local).AddTicks(7810), false, "Developer", new DateTime(2022, 10, 24, 12, 14, 12, 937, DateTimeKind.Local).AddTicks(7843) });

            migrationBuilder.InsertData(
                table: "SequenceNumbers",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "Number", "UpdateDateTime" },
                values: new object[] { new Guid("94a90159-e01e-42b8-b66d-3815e572d2bd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 24, 12, 14, 12, 937, DateTimeKind.Local).AddTicks(8838), false, "RegisterDiscount", 1, new DateTime(2022, 10, 24, 12, 14, 12, 937, DateTimeKind.Local).AddTicks(8839) });

            migrationBuilder.InsertData(
                table: "SequenceNumbers",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "Number", "UpdateDateTime" },
                values: new object[] { new Guid("dda43014-f90a-4a82-ba04-93da0bc7e5c6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 24, 12, 14, 12, 937, DateTimeKind.Local).AddTicks(8800), false, "TracingCode", 1, new DateTime(2022, 10, 24, 12, 14, 12, 937, DateTimeKind.Local).AddTicks(8809) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActivationCode", "BirthDate", "CellPhoneNumber", "DeleteDateTime", "EmailAddress", "Especialty", "FirstName", "FullName", "Gender", "InsertDateTime", "IsActive", "IsEdited", "LastName", "MENumber", "NationalCode", "OfficeAddress", "Password", "PhoneNumber", "RoleId", "UpdateDateTime", "Username" },
                values: new object[] { new Guid("b50df749-fff2-4a7c-afb4-f22a4e0afc50"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "moghadasian.vahidreza@gmail.com", null, null, null, 2, new DateTime(2022, 10, 24, 12, 14, 12, 937, DateTimeKind.Local).AddTicks(8041), true, false, null, null, null, null, "483742cefbc362f54f266c92e1b38eafe6795f2ec8f44efef644ffd7afaf213c", null, new Guid("81babea2-1f23-4b88-b607-693fa9ea2cfb"), new DateTime(2022, 10, 24, 12, 14, 12, 937, DateTimeKind.Local).AddTicks(8043), "developer" });
        }
    }
}
