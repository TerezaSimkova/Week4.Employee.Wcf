using Microsoft.EntityFrameworkCore.Migrations;

namespace Week4.Library.EF.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "_BookId",
                table: "Prestito",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prestito__BookId",
                table: "Prestito",
                column: "_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestito_Book__BookId",
                table: "Prestito",
                column: "_BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestito_Book__BookId",
                table: "Prestito");

            migrationBuilder.DropIndex(
                name: "IX_Prestito__BookId",
                table: "Prestito");

            migrationBuilder.DropColumn(
                name: "_BookId",
                table: "Prestito");
        }
    }
}
