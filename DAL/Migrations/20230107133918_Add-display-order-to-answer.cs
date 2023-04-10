using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Adddisplayordertoanswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "UpdateDateTime" },
                values: new object[] { new Guid("61707dc4-66e6-47f5-ac32-a464da195ffe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 7, 17, 9, 18, 224, DateTimeKind.Local).AddTicks(8441), false, "Developer", new DateTime(2023, 1, 7, 17, 9, 18, 224, DateTimeKind.Local).AddTicks(8476) });

            migrationBuilder.InsertData(
                table: "SequenceNumbers",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "Number", "UpdateDateTime" },
                values: new object[] { new Guid("cf121c18-02c8-471a-b85b-f5d4b4024b4a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 7, 17, 9, 18, 224, DateTimeKind.Local).AddTicks(9043), false, "RegisterDiscount", 1, new DateTime(2023, 1, 7, 17, 9, 18, 224, DateTimeKind.Local).AddTicks(9045) });

            migrationBuilder.InsertData(
                table: "SequenceNumbers",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "Number", "UpdateDateTime" },
                values: new object[] { new Guid("dc9bcd3f-a308-4e20-9f23-78f3dca40330"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 7, 17, 9, 18, 224, DateTimeKind.Local).AddTicks(9011), false, "TracingCode", 1, new DateTime(2023, 1, 7, 17, 9, 18, 224, DateTimeKind.Local).AddTicks(9014) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActivationCode", "BirthDate", "CellPhoneNumber", "DeleteDateTime", "EmailAddress", "Especialty", "FirstName", "FullName", "Gender", "InsertDateTime", "IsActive", "IsEdited", "LastName", "MENumber", "NationalCode", "OfficeAddress", "Password", "PhoneNumber", "RoleId", "UpdateDateTime", "Username" },
                values: new object[] { new Guid("7123c7dd-432a-4d09-9efa-3a12b8b2e180"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@fidarafzar.ir", null, null, null, 2, new DateTime(2023, 1, 7, 17, 9, 18, 224, DateTimeKind.Local).AddTicks(8680), true, false, null, null, null, null, "069d28fa7cad5da31006c8a765c831a69ac1866ff32fae5ef3f9c8ae19118b86", null, new Guid("61707dc4-66e6-47f5-ac32-a464da195ffe"), new DateTime(2023, 1, 7, 17, 9, 18, 224, DateTimeKind.Local).AddTicks(8683), "developer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SequenceNumbers",
                keyColumn: "Id",
                keyValue: new Guid("cf121c18-02c8-471a-b85b-f5d4b4024b4a"));

            migrationBuilder.DeleteData(
                table: "SequenceNumbers",
                keyColumn: "Id",
                keyValue: new Guid("dc9bcd3f-a308-4e20-9f23-78f3dca40330"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7123c7dd-432a-4d09-9efa-3a12b8b2e180"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("61707dc4-66e6-47f5-ac32-a464da195ffe"));

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Answers");

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
    }
}
