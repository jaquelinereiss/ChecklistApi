using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checklist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CascadeChecklistNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SUBNOTES_NOTES_NoteId",
                table: "SUBNOTES");

            migrationBuilder.AddForeignKey(
                name: "FK_SUBNOTES_NOTES_NoteId",
                table: "SUBNOTES",
                column: "NoteId",
                principalTable: "NOTES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SUBNOTES_NOTES_NoteId",
                table: "SUBNOTES");

            migrationBuilder.AddForeignKey(
                name: "FK_SUBNOTES_NOTES_NoteId",
                table: "SUBNOTES",
                column: "NoteId",
                principalTable: "NOTES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
