using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.Persistence.Migrations
{
    public partial class createdreader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("465837fb-452f-4c18-b7ac-64c391c2d628"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("8d45cb50-22e5-4fb7-94d5-d7f8c56cc5da"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("d5788740-8f61-4c1d-ab01-65f61d6b4246"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("e8d143e8-4537-499b-a95d-24fba3b110fd"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "SubType",
                keyColumn: "Id",
                keyValue: new Guid("706ae02d-bfdb-4520-87d1-9ec64f037932"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "SubType",
                keyColumn: "Id",
                keyValue: new Guid("80d337ea-229b-40b4-83db-4b7011717a15"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "SubType",
                keyColumn: "Id",
                keyValue: new Guid("a943059e-f4f7-4281-9f0d-c2dcf68699db"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "SubType",
                keyColumn: "Id",
                keyValue: new Guid("bb25ee94-06b4-40d0-bea4-ea9e91dde944"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "SubType",
                keyColumn: "Id",
                keyValue: new Guid("ce4cb757-823f-403e-953d-6c389b646308"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "SubType",
                keyColumn: "Id",
                keyValue: new Guid("f5e5497b-03be-42ae-b5e7-f7b965f473df"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "SubType",
                keyColumn: "Id",
                keyValue: new Guid("ffe742ec-b81b-4882-ba40-28207231047f"));

            migrationBuilder.CreateTable(
                name: "Reader",
                schema: "BookContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reader_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "BookContext",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "BookContext",
                table: "Author",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("caaf6ee0-22b9-4cf7-9526-9d36358eba2e"), "William Shakespeare" },
                    { new Guid("241eb9a8-2206-49a4-9095-000002cd7ed8"), "William Faulkner" },
                    { new Guid("de9cf188-1968-4d3a-a148-320bc3a6799a"), "Henry James" },
                    { new Guid("cc000d2c-9f05-4ed5-918d-faecd6717feb"), "Jane Austen" }
                });

            migrationBuilder.InsertData(
                schema: "BookContext",
                table: "SubType",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[,]
                {
                    { new Guid("9d8831d1-6a89-41fc-b77d-2880013862ac"), "Painting", new Guid("f3a92796-e896-47d3-8311-92f6ecc97f85") },
                    { new Guid("85a3bfe0-753b-4be6-b9eb-b2300aa7a7cc"), "Poems", new Guid("f3a92796-e896-47d3-8311-92f6ecc97f85") },
                    { new Guid("5ade84a3-2262-4771-b191-089aee4501c7"), "Adventure", new Guid("f3a92796-e896-47d3-8311-92f6ecc97f85") },
                    { new Guid("73f205d5-f70c-4d20-bcad-a6dd46b44fdc"), "Detective and Mystery", new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce") },
                    { new Guid("7d51cc5e-499b-4379-b971-3a6a362fdb7f"), "Fantasy", new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce") },
                    { new Guid("6e2e35f7-2560-4ced-bbfc-7d34d179cdf4"), "Horror", new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce") },
                    { new Guid("916bac7a-36db-48c2-a9a3-df859766b304"), "Literary Fiction", new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reader_BookId",
                schema: "BookContext",
                table: "Reader",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reader",
                schema: "BookContext");

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("241eb9a8-2206-49a4-9095-000002cd7ed8"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("caaf6ee0-22b9-4cf7-9526-9d36358eba2e"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("cc000d2c-9f05-4ed5-918d-faecd6717feb"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("de9cf188-1968-4d3a-a148-320bc3a6799a"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "SubType",
                keyColumn: "Id",
                keyValue: new Guid("5ade84a3-2262-4771-b191-089aee4501c7"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "SubType",
                keyColumn: "Id",
                keyValue: new Guid("6e2e35f7-2560-4ced-bbfc-7d34d179cdf4"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "SubType",
                keyColumn: "Id",
                keyValue: new Guid("73f205d5-f70c-4d20-bcad-a6dd46b44fdc"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "SubType",
                keyColumn: "Id",
                keyValue: new Guid("7d51cc5e-499b-4379-b971-3a6a362fdb7f"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "SubType",
                keyColumn: "Id",
                keyValue: new Guid("85a3bfe0-753b-4be6-b9eb-b2300aa7a7cc"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "SubType",
                keyColumn: "Id",
                keyValue: new Guid("916bac7a-36db-48c2-a9a3-df859766b304"));

            migrationBuilder.DeleteData(
                schema: "BookContext",
                table: "SubType",
                keyColumn: "Id",
                keyValue: new Guid("9d8831d1-6a89-41fc-b77d-2880013862ac"));

            migrationBuilder.InsertData(
                schema: "BookContext",
                table: "Author",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("e8d143e8-4537-499b-a95d-24fba3b110fd"), "William Shakespeare" },
                    { new Guid("465837fb-452f-4c18-b7ac-64c391c2d628"), "William Faulkner" },
                    { new Guid("d5788740-8f61-4c1d-ab01-65f61d6b4246"), "Henry James" },
                    { new Guid("8d45cb50-22e5-4fb7-94d5-d7f8c56cc5da"), "Jane Austen" }
                });

            migrationBuilder.InsertData(
                schema: "BookContext",
                table: "SubType",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[,]
                {
                    { new Guid("ffe742ec-b81b-4882-ba40-28207231047f"), "Painting", new Guid("f3a92796-e896-47d3-8311-92f6ecc97f85") },
                    { new Guid("f5e5497b-03be-42ae-b5e7-f7b965f473df"), "Poems", new Guid("f3a92796-e896-47d3-8311-92f6ecc97f85") },
                    { new Guid("bb25ee94-06b4-40d0-bea4-ea9e91dde944"), "Adventure", new Guid("f3a92796-e896-47d3-8311-92f6ecc97f85") },
                    { new Guid("706ae02d-bfdb-4520-87d1-9ec64f037932"), "Detective and Mystery", new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce") },
                    { new Guid("a943059e-f4f7-4281-9f0d-c2dcf68699db"), "Fantasy", new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce") },
                    { new Guid("80d337ea-229b-40b4-83db-4b7011717a15"), "Horror", new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce") },
                    { new Guid("ce4cb757-823f-403e-953d-6c389b646308"), "Literary Fiction", new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce") }
                });
        }
    }
}
