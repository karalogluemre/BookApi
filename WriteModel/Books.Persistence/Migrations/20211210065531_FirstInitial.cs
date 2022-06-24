using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.Persistence.Migrations
{
    public partial class FirstInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BookContext");

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "BookContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                schema: "BookContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubType",
                schema: "BookContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubType_Type_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "BookContext",
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "BookContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    SubTypeId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "BookContext",
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_SubType_SubTypeId",
                        column: x => x.SubTypeId,
                        principalSchema: "BookContext",
                        principalTable: "SubType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "BookContext",
                table: "Author",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9fdf3b04-acce-426e-b317-d17944e333c1"), "William Shakespeare" },
                    { new Guid("96237378-bb91-44aa-b817-2402c29a89cf"), "William Faulkner" },
                    { new Guid("743e6856-523e-440b-a654-a8cba7795d0b"), "Henry James" },
                    { new Guid("c623c015-8a3e-4848-b1f4-542f93e6ca97"), "Jane Austen" }
                });

            migrationBuilder.InsertData(
                schema: "BookContext",
                table: "Type",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("f3a92796-e896-47d3-8311-92f6ecc97f85"), "Children" },
                    { new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce"), "Adult" }
                });

            migrationBuilder.InsertData(
                schema: "BookContext",
                table: "SubType",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[,]
                {
                    { new Guid("091f7c15-9ca9-40ff-97e3-d7e905acf28f"), "Painting", new Guid("f3a92796-e896-47d3-8311-92f6ecc97f85") },
                    { new Guid("8873f861-b8e1-4156-89c9-586c5359ea63"), "Poems", new Guid("f3a92796-e896-47d3-8311-92f6ecc97f85") },
                    { new Guid("349f1d56-acf0-4a8d-90ca-0c6973087ab7"), "Adventure", new Guid("f3a92796-e896-47d3-8311-92f6ecc97f85") },
                    { new Guid("d6a334d0-af8a-4ec4-b8ba-8f209d9236a5"), "Detective and Mystery", new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce") },
                    { new Guid("90be391e-2dcc-49a0-9efc-00c820768f62"), "Fantasy", new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce") },
                    { new Guid("ab9b9bc6-42ea-4e35-8692-040a3a8a4918"), "Horror", new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce") },
                    { new Guid("45454bdc-0218-4ea2-ade8-0c942fd4c9e7"), "Literary Fiction", new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                schema: "BookContext",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_SubTypeId",
                schema: "BookContext",
                table: "Book",
                column: "SubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubType_TypeId",
                schema: "BookContext",
                table: "SubType",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book",
                schema: "BookContext");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "BookContext");

            migrationBuilder.DropTable(
                name: "SubType",
                schema: "BookContext");

            migrationBuilder.DropTable(
                name: "Type",
                schema: "BookContext");
        }
    }
}
