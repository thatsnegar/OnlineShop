using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class addtrackingcodetoorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SequenceNumbers",
                keyColumn: "Id",
                keyValue: new Guid("c6307815-a53a-4e77-8fa8-3dcc5c7de5c5"));

            migrationBuilder.DeleteData(
                table: "SequenceNumbers",
                keyColumn: "Id",
                keyValue: new Guid("e79f0e38-da7e-4e22-9323-8ab3d64cb7a9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("335db704-6088-4852-add2-8d6fd74cb14d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4f2c5f5a-df4e-4627-a42f-139039e8bec0"));

            migrationBuilder.AddColumn<bool>(
                name: "GenerateTrackingNumberAutomatically",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "TrackingNumber",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "GenerateTrackingNumberAutomatically",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TrackingNumber",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "UpdateDateTime" },
                values: new object[] { new Guid("4f2c5f5a-df4e-4627-a42f-139039e8bec0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 23, 12, 47, 49, 116, DateTimeKind.Local).AddTicks(4226), false, "Developer", new DateTime(2022, 10, 23, 12, 47, 49, 116, DateTimeKind.Local).AddTicks(4260) });

            migrationBuilder.InsertData(
                table: "SequenceNumbers",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "Number", "UpdateDateTime" },
                values: new object[] { new Guid("c6307815-a53a-4e77-8fa8-3dcc5c7de5c5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 23, 12, 47, 49, 116, DateTimeKind.Local).AddTicks(5241), false, "RegisterDiscount", 1, new DateTime(2022, 10, 23, 12, 47, 49, 116, DateTimeKind.Local).AddTicks(5243) });

            migrationBuilder.InsertData(
                table: "SequenceNumbers",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "Number", "UpdateDateTime" },
                values: new object[] { new Guid("e79f0e38-da7e-4e22-9323-8ab3d64cb7a9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 23, 12, 47, 49, 116, DateTimeKind.Local).AddTicks(5212), false, "TracingCode", 1, new DateTime(2022, 10, 23, 12, 47, 49, 116, DateTimeKind.Local).AddTicks(5218) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActivationCode", "BirthDate", "CellPhoneNumber", "DeleteDateTime", "EmailAddress", "Especialty", "FirstName", "FullName", "Gender", "InsertDateTime", "IsActive", "IsEdited", "LastName", "MENumber", "NationalCode", "OfficeAddress", "Password", "PhoneNumber", "RoleId", "UpdateDateTime", "Username" },
                values: new object[] { new Guid("335db704-6088-4852-add2-8d6fd74cb14d"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "moghadasian.vahidreza@gmail.com", null, null, null, 2, new DateTime(2022, 10, 23, 12, 47, 49, 116, DateTimeKind.Local).AddTicks(4502), true, false, null, null, null, null, "483742cefbc362f54f266c92e1b38eafe6795f2ec8f44efef644ffd7afaf213c", null, new Guid("4f2c5f5a-df4e-4627-a42f-139039e8bec0"), new DateTime(2022, 10, 23, 12, 47, 49, 116, DateTimeKind.Local).AddTicks(4506), "developer" });
        }
    }
}
