using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class addcountinmessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SequenceNumbers",
                keyColumn: "Id",
                keyValue: new Guid("96c84539-7cdf-4b8d-a84b-dd028429d2c6"));

            migrationBuilder.DeleteData(
                table: "SequenceNumbers",
                keyColumn: "Id",
                keyValue: new Guid("c1916263-6ed0-459b-bcd4-4b73ce35f549"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1561bf13-f3b0-453e-8ef0-72517a9c679b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7b355b8b-0a15-4ae0-879e-f8e307d3ea93"));

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Messages");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "UpdateDateTime" },
                values: new object[] { new Guid("7b355b8b-0a15-4ae0-879e-f8e307d3ea93"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 23, 16, 32, 6, 145, DateTimeKind.Local).AddTicks(946), false, "Developer", new DateTime(2022, 10, 23, 16, 32, 6, 145, DateTimeKind.Local).AddTicks(976) });

            migrationBuilder.InsertData(
                table: "SequenceNumbers",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "Number", "UpdateDateTime" },
                values: new object[] { new Guid("96c84539-7cdf-4b8d-a84b-dd028429d2c6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 23, 16, 32, 6, 145, DateTimeKind.Local).AddTicks(1967), false, "TracingCode", 1, new DateTime(2022, 10, 23, 16, 32, 6, 145, DateTimeKind.Local).AddTicks(1976) });

            migrationBuilder.InsertData(
                table: "SequenceNumbers",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "Number", "UpdateDateTime" },
                values: new object[] { new Guid("c1916263-6ed0-459b-bcd4-4b73ce35f549"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 23, 16, 32, 6, 145, DateTimeKind.Local).AddTicks(2061), false, "RegisterDiscount", 1, new DateTime(2022, 10, 23, 16, 32, 6, 145, DateTimeKind.Local).AddTicks(2063) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActivationCode", "BirthDate", "CellPhoneNumber", "DeleteDateTime", "EmailAddress", "Especialty", "FirstName", "FullName", "Gender", "InsertDateTime", "IsActive", "IsEdited", "LastName", "MENumber", "NationalCode", "OfficeAddress", "Password", "PhoneNumber", "RoleId", "UpdateDateTime", "Username" },
                values: new object[] { new Guid("1561bf13-f3b0-453e-8ef0-72517a9c679b"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "moghadasian.vahidreza@gmail.com", null, null, null, 2, new DateTime(2022, 10, 23, 16, 32, 6, 145, DateTimeKind.Local).AddTicks(1177), true, false, null, null, null, null, "483742cefbc362f54f266c92e1b38eafe6795f2ec8f44efef644ffd7afaf213c", null, new Guid("7b355b8b-0a15-4ae0-879e-f8e307d3ea93"), new DateTime(2022, 10, 23, 16, 32, 6, 145, DateTimeKind.Local).AddTicks(1182), "developer" });
        }
    }
}
