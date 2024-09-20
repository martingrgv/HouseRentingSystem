using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class AddedAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "502a0272-e0ea-49bb-b829-eb37357a1e0e", "AQAAAAEAACcQAAAAEBdjayU5v1RZ6wVF8EPTNel5O6aegZ6znyWeUqjZpLwDNWgtZkvJhjnvuKGa/LAAtQ==", "3b9d8632-b4e8-4f96-8c44-3ff33664b7e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c2a362c-8a4e-4d79-948e-019bc70f8d90", "admin@mail.com", "AQAAAAEAACcQAAAAEIkT4OQfPb/zcaQ7dTWpOCDihXS3pStLlnZhnqAtFWV7sImNx00ZIKx4F8L14Zhyhw==", "7350c1aa-1d2b-4b35-bfe0-5c1669ca227a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e420a0f-fb5b-420b-892d-aa24b8c4190f", "AQAAAAEAACcQAAAAEH+FrmXj6SOkEfoU5TjP5/xlWten8tuL96vcxw/TRB6lVIWOC9wmWh049EOFwf4QPw==", "649d7721-cd8f-4391-8e33-226f86fd5b65" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52af4219-67ea-423e-a88d-fa7033505a37", "AQAAAAEAACcQAAAAEKuLUA4F0UkpyJxfJH48MD1ewHAUP6pKJn06AWpeAakPj7mZDPmCPIHQUJ/OPCB4PQ==", "d61aa7d0-6e0b-4a3e-9ab2-876386e247d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b026271-d0ec-4e59-9996-085bc33b7ed9", null, "AQAAAAEAACcQAAAAEHa7xU3oLyYFqBNPyaJ9A1aAq4Jh9g0Hfh5fLEVm/y2D+UpDfrF9m2iT2UjEkqjnFw==", "5781d725-a582-4feb-8ce5-49c5163b4db6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "036b6dd9-1580-43ed-ae8c-0d4e80fd44b8", "AQAAAAEAACcQAAAAEKv4CT7F2HBObZzbJQYrXM8AxSd7XyiHHT7lFKGvHinHC7VQIBzaI9Awl/f0W5/rhA==", "7fdaa91f-f0c6-4534-90c0-cd5508c2d112" });
        }
    }
}
