using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionandUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "userid",
                table: "transactions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_transactions_userid",
                table: "transactions",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_users_userid",
                table: "transactions",
                column: "userid",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_users_userid",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_userid",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "transactions");
        }
    }
}
