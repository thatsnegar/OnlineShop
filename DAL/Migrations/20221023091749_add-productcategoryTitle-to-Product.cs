using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class addproductcategoryTitletoProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SequenceNumbers",
                keyColumn: "Id",
                keyValue: new Guid("454e56eb-7d6d-4425-8ef5-d34003e9250c"));

            migrationBuilder.DeleteData(
                table: "SequenceNumbers",
                keyColumn: "Id",
                keyValue: new Guid("82875fb9-7c5c-46f9-91f8-3f7bab6488f6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("102a51f0-2878-4196-8aa5-d9860f9b923d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("75e9742b-f37b-41ea-8ac8-8147a731e8c2"));

            migrationBuilder.AddColumn<string>(
                name: "ProductCategoryTitle",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ProductCategoryTitle",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "UpdateDateTime" },
                values: new object[] { new Guid("75e9742b-f37b-41ea-8ac8-8147a731e8c2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 22, 14, 0, 54, 23, DateTimeKind.Local).AddTicks(8712), false, "Developer", new DateTime(2022, 10, 22, 14, 0, 54, 23, DateTimeKind.Local).AddTicks(8743) });

            migrationBuilder.InsertData(
                table: "SequenceNumbers",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "Number", "UpdateDateTime" },
                values: new object[] { new Guid("454e56eb-7d6d-4425-8ef5-d34003e9250c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 22, 14, 0, 54, 23, DateTimeKind.Local).AddTicks(9653), false, "TracingCode", 1, new DateTime(2022, 10, 22, 14, 0, 54, 23, DateTimeKind.Local).AddTicks(9659) });

            migrationBuilder.InsertData(
                table: "SequenceNumbers",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "IsEdited", "Name", "Number", "UpdateDateTime" },
                values: new object[] { new Guid("82875fb9-7c5c-46f9-91f8-3f7bab6488f6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 22, 14, 0, 54, 23, DateTimeKind.Local).AddTicks(9683), false, "RegisterDiscount", 1, new DateTime(2022, 10, 22, 14, 0, 54, 23, DateTimeKind.Local).AddTicks(9685) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActivationCode", "BirthDate", "CellPhoneNumber", "DeleteDateTime", "EmailAddress", "Especialty", "FirstName", "FullName", "Gender", "InsertDateTime", "IsActive", "IsEdited", "LastName", "MENumber", "NationalCode", "OfficeAddress", "Password", "PhoneNumber", "RoleId", "UpdateDateTime", "Username" },
                values: new object[] { new Guid("102a51f0-2878-4196-8aa5-d9860f9b923d"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "moghadasian.vahidreza@gmail.com", null, null, null, 2, new DateTime(2022, 10, 22, 14, 0, 54, 23, DateTimeKind.Local).AddTicks(8948), true, false, null, null, null, null, "483742cefbc362f54f266c92e1b38eafe6795f2ec8f44efef644ffd7afaf213c", null, new Guid("75e9742b-f37b-41ea-8ac8-8147a731e8c2"), new DateTime(2022, 10, 22, 14, 0, 54, 23, DateTimeKind.Local).AddTicks(8952), "developer" });
        }
    }
}
