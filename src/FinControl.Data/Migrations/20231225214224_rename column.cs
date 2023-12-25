using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class renamecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_recurrences_RecurrenceId",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "RecurrenceId",
                table: "transactions",
                newName: "recurrenceid");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_RecurrenceId",
                table: "transactions",
                newName: "IX_transactions_recurrenceid");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_recurrences_recurrenceid",
                table: "transactions",
                column: "recurrenceid",
                principalTable: "recurrences",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_recurrences_recurrenceid",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "recurrenceid",
                table: "transactions",
                newName: "RecurrenceId");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_recurrenceid",
                table: "transactions",
                newName: "IX_transactions_RecurrenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_recurrences_RecurrenceId",
                table: "transactions",
                column: "RecurrenceId",
                principalTable: "recurrences",
                principalColumn: "id");
        }
    }
}
