using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Endpoint.Migrations
{
    /// <inheritdoc />
    public partial class Reservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservation_tables_TableId",
                table: "reservation");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "reservation",
                newName: "table_id");

            migrationBuilder.RenameIndex(
                name: "IX_reservation_TableId",
                table: "reservation",
                newName: "IX_reservation_table_id");

            migrationBuilder.AddForeignKey(
                name: "FK_reservation_tables_table_id",
                table: "reservation",
                column: "table_id",
                principalTable: "tables",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservation_tables_table_id",
                table: "reservation");

            migrationBuilder.RenameColumn(
                name: "table_id",
                table: "reservation",
                newName: "TableId");

            migrationBuilder.RenameIndex(
                name: "IX_reservation_table_id",
                table: "reservation",
                newName: "IX_reservation_TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_reservation_tables_TableId",
                table: "reservation",
                column: "TableId",
                principalTable: "tables",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
