using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class AgentUniquePhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06b04832-dce4-484b-a337-06e975b00cf6", "AQAAAAEAACcQAAAAEIjAfSqXgaASMA4mXOYotbbwJgdUH0Sk/DpWznl+VS7TylIoS+m99SIYXh13cirfkQ==", "3401c89d-6689-416f-908f-dd31eed3ea3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3b50015-6c3d-421d-a4fa-6ea3566d3840", "AQAAAAEAACcQAAAAEB+nOXLk4Sm2+UhVxwuwH/Z1Sq/qt2GtvUHbFyYU81DQKNupGAZGRJaQJXLbdxDbWg==", "a8d0cbf4-4c49-427f-b383-4036a4b13132" });
        }
    }
}
