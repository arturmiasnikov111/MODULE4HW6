using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MODULE4HW6.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Song_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistsToSong",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistsToSong", x => new { x.ArtistId, x.SongId });
                    table.ForeignKey(
                        name: "FK_ArtistsToSong_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistsToSong_Song_SongId",
                        column: x => x.SongId,
                        principalTable: "Song",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "ArtistId", "DateOfBirth", "Email", "InstagramUrl", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "asd@aa.aa", "instagram.com/artur", "Artur", "05055333" },
                    { 2, new DateTime(1990, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "asd@aa.aa11", "instagram.com/artur1", "Artur1", "0339393" },
                    { 3, new DateTime(1990, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "asd@aa.aa22", "instagram.com/artur2", "Artur2", "0339393" },
                    { 4, new DateTime(1989, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "asd@aa.aa33", "instagram.com/artur3", "Artur3", "023283" },
                    { 5, new DateTime(1989, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "asd@aa.aa44", "instagram.com/artur4", "Artur14", "123823" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "Title" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Rap" },
                    { 3, "Trance" },
                    { 4, "Techno" },
                    { 5, "Pop" }
                });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "SongId", "Duration", "GenreId", "ReleasedDate", "Title" },
                values: new object[,]
                {
                    { 1, "4m.56s", 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song#1" },
                    { 2, "5m.56s", 2, new DateTime(2019, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song#2" },
                    { 5, "2m.16s", 2, new DateTime(2015, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song#5" },
                    { 3, "2m.16s", 3, new DateTime(2018, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song#3" },
                    { 4, "4m.56s", 4, new DateTime(2017, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song#4" }
                });

            migrationBuilder.InsertData(
                table: "ArtistsToSong",
                columns: new[] { "ArtistId", "SongId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 },
                    { 4, 5 },
                    { 1, 3 },
                    { 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistsToSong_SongId",
                table: "ArtistsToSong",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_GenreId",
                table: "Song",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistsToSong");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
