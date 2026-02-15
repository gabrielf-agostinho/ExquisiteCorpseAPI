using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExquisiteCorpseAPI.Migrations
{
    /// <inheritdoc />
    public partial class Genders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "subjects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "adjectives",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "genders",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 1, "Neutral" },
                    { 2, "Male" },
                    { 3, "Female" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_subjects_GenderId",
                table: "subjects",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_adjectives_GenderId",
                table: "adjectives",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_genders_Label",
                table: "genders",
                column: "Label",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_adjectives_genders_GenderId",
                table: "adjectives",
                column: "GenderId",
                principalTable: "genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subjects_genders_GenderId",
                table: "subjects",
                column: "GenderId",
                principalTable: "genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adjectives_genders_GenderId",
                table: "adjectives");

            migrationBuilder.DropForeignKey(
                name: "FK_subjects_genders_GenderId",
                table: "subjects");

            migrationBuilder.DropTable(
                name: "genders");

            migrationBuilder.DropIndex(
                name: "IX_subjects_GenderId",
                table: "subjects");

            migrationBuilder.DropIndex(
                name: "IX_adjectives_GenderId",
                table: "adjectives");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "adjectives");
        }
    }
}
