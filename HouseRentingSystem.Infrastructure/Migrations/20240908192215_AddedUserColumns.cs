using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class AddedUserColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e0096fa-2915-4f71-910e-b7ce6ac1c67d", "George", "Washington", "AQAAAAEAACcQAAAAEJptidscfy9NMqDrCH72c8rStdV1rWvGEa71QI8XzJd+5yhYj9RSEHp/3XXthK8LzQ==", "574d44a4-75d4-4cfc-9d13-5081e86a9296" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18772335-06eb-4420-8ec0-6f4ab55d6fed", "Donald", "Trump", "AQAAAAEAACcQAAAAELn1TTb2l+y33NuC1Zj7WQ7racoXGnuG3Ro/3VWetHtsNj4E188y4AYz31+06TltmA==", "b3145f72-035a-438c-a038-ee49e667d7ea" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed6a45bd-07ac-4cd4-8aa1-52d159fc51ab", "AQAAAAEAACcQAAAAEE+PZnqNts568+Z2UBi/LH8MKHd+ejtW8wo0QNrAUzTYJrlxMQDHzPKR/aGIV8FxNg==", "ece919c1-3fef-466f-a3a6-d7f4814d1cf7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f867b12-48ea-4db0-bc0c-0b25149ee860", "AQAAAAEAACcQAAAAEICMqHeHXhp9NCiWCIjxqwsNdBAbmTM8S/7owX9xCcMMtWVehaG4DMctiQf751VDog==", "f419338f-0072-417b-adb5-a1e2bc67dcfe" });
        }
    }
}
