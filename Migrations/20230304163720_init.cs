using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfCoreTask.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fio = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    PublisherId = table.Column<int>(type: "INTEGER", nullable: false),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "INTEGER", nullable: false),
                    BooksId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Fio" },
                values: new object[,]
                {
                    { 1, "Author_1" },
                    { 2, "Author_2" },
                    { 3, "Author_3" },
                    { 4, "Author_4" },
                    { 5, "Author_5" },
                    { 6, "Author_6" },
                    { 7, "Author_7" },
                    { 8, "Author_8" },
                    { 9, "Author_9" },
                    { 10, "Author_10" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Genre_1" },
                    { 2, "Genre_2" },
                    { 3, "Genre_3" },
                    { 4, "Genre_4" },
                    { 5, "Genre_5" },
                    { 6, "Genre_6" },
                    { 7, "Genre_7" },
                    { 8, "Genre_8" },
                    { 9, "Genre_9" },
                    { 10, "Genre_10" },
                    { 11, "Genre_11" },
                    { 12, "Genre_12" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Publisher_1" },
                    { 2, "Publisher_2" },
                    { 3, "Publisher_3" },
                    { 4, "Publisher_4" },
                    { 5, "Publisher_5" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "GenreId", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, 4, "Book_$1" },
                    { 2, 1, 2, "Book_$2" },
                    { 3, 1, 3, "Book_$3" },
                    { 4, 1, 1, "Book_$4" },
                    { 5, 2, 3, "Book_$5" },
                    { 6, 2, 2, "Book_$6" },
                    { 7, 2, 3, "Book_$7" },
                    { 8, 2, 3, "Book_$8" },
                    { 9, 3, 3, "Book_$9" },
                    { 10, 3, 5, "Book_$10" },
                    { 11, 3, 1, "Book_$11" },
                    { 12, 3, 1, "Book_$12" },
                    { 13, 4, 1, "Book_$13" },
                    { 14, 4, 2, "Book_$14" },
                    { 15, 4, 1, "Book_$15" },
                    { 16, 4, 4, "Book_$16" },
                    { 17, 5, 5, "Book_$17" },
                    { 18, 5, 2, "Book_$18" },
                    { 19, 5, 1, "Book_$19" },
                    { 20, 5, 3, "Book_$20" },
                    { 21, 6, 1, "Book_$21" },
                    { 22, 6, 3, "Book_$22" },
                    { 23, 6, 2, "Book_$23" },
                    { 24, 6, 3, "Book_$24" },
                    { 25, 7, 4, "Book_$25" },
                    { 26, 7, 4, "Book_$26" },
                    { 27, 7, 1, "Book_$27" },
                    { 28, 7, 2, "Book_$28" },
                    { 29, 8, 2, "Book_$29" },
                    { 30, 8, 3, "Book_$30" },
                    { 31, 8, 5, "Book_$31" },
                    { 32, 8, 3, "Book_$32" },
                    { 33, 9, 2, "Book_$33" },
                    { 34, 9, 1, "Book_$34" },
                    { 35, 9, 4, "Book_$35" },
                    { 36, 9, 1, "Book_$36" },
                    { 37, 10, 3, "Book_$37" },
                    { 38, 10, 2, "Book_$38" },
                    { 39, 10, 5, "Book_$39" },
                    { 40, 10, 1, "Book_$40" },
                    { 41, 11, 3, "Book_$41" },
                    { 42, 11, 4, "Book_$42" },
                    { 43, 11, 2, "Book_$43" },
                    { 44, 11, 2, "Book_$44" },
                    { 45, 12, 3, "Book_$45" },
                    { 46, 12, 1, "Book_$46" },
                    { 47, 12, 5, "Book_$47" },
                    { 48, 12, 1, "Book_$48" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 1, 29 },
                    { 1, 38 },
                    { 1, 42 },
                    { 2, 14 },
                    { 2, 16 },
                    { 2, 28 },
                    { 2, 30 },
                    { 2, 40 },
                    { 3, 3 },
                    { 3, 9 },
                    { 3, 21 },
                    { 3, 33 },
                    { 3, 44 },
                    { 4, 2 },
                    { 4, 7 },
                    { 4, 8 },
                    { 4, 10 },
                    { 4, 23 },
                    { 5, 13 },
                    { 5, 20 },
                    { 5, 22 },
                    { 5, 43 },
                    { 5, 46 },
                    { 5, 48 },
                    { 6, 11 },
                    { 6, 15 },
                    { 6, 18 },
                    { 6, 37 },
                    { 6, 41 },
                    { 6, 45 },
                    { 7, 1 },
                    { 7, 39 },
                    { 8, 6 },
                    { 8, 25 },
                    { 8, 26 },
                    { 8, 27 },
                    { 9, 17 },
                    { 9, 24 },
                    { 9, 34 },
                    { 9, 47 },
                    { 10, 4 },
                    { 10, 12 },
                    { 10, 19 },
                    { 10, 31 },
                    { 10, 32 },
                    { 10, 35 },
                    { 10, 36 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Id",
                table: "Books",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Id",
                table: "Genres",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_Id",
                table: "Publishers",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
