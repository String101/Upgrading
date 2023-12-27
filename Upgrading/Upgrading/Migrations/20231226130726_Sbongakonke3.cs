using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Upgrading.Migrations
{
    /// <inheritdoc />
    public partial class Sbongakonke3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Registrations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_StudentId",
                table: "Registrations",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Students_StudentId",
                table: "Registrations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Students_StudentId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_StudentId",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Registrations");
        }
    }
}
