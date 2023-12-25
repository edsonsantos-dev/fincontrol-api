using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    addedon = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    addedby = table.Column<Guid>(type: "uuid", nullable: false),
                    modifiedon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recurrences",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    frequency = table.Column<int>(type: "integer", nullable: false),
                    addedon = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    addedby = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recurrences", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    accountid = table.Column<Guid>(type: "uuid", nullable: false),
                    addedon = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    addedby = table.Column<Guid>(type: "uuid", nullable: false),
                    modifiedon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<Guid>(type: "uuid", nullable: true),
                    removedn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    removedby = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_categories_accounts_accountid",
                        column: x => x.accountid,
                        principalTable: "accounts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    WhatsAppNumber = table.Column<string>(type: "text", nullable: true),
                    ConfirmedWhatsAppNumber = table.Column<bool>(type: "boolean", nullable: true),
                    passwordhash = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    accountid = table.Column<Guid>(type: "uuid", nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false),
                    addedon = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    addedby = table.Column<Guid>(type: "uuid", nullable: false),
                    modifiedon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_accounts_accountid",
                        column: x => x.accountid,
                        principalTable: "accounts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    categoryid = table.Column<Guid>(type: "uuid", nullable: false),
                    RecurrenceId = table.Column<Guid>(type: "uuid", nullable: true),
                    accountid = table.Column<Guid>(type: "uuid", nullable: false),
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    addedon = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    addedby = table.Column<Guid>(type: "uuid", nullable: false),
                    modifiedon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<Guid>(type: "uuid", nullable: true),
                    removedn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    removedby = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_transactions_accounts_accountid",
                        column: x => x.accountid,
                        principalTable: "accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_recurrences_RecurrenceId",
                        column: x => x.RecurrenceId,
                        principalTable: "recurrences",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_accountid",
                table: "categories",
                column: "accountid");

            migrationBuilder.CreateIndex(
                name: "IX_categories_addedby",
                table: "categories",
                column: "addedby");

            migrationBuilder.CreateIndex(
                name: "IX_categories_addedon",
                table: "categories",
                column: "addedon");

            migrationBuilder.CreateIndex(
                name: "IX_categories_isactive",
                table: "categories",
                column: "isactive");

            migrationBuilder.CreateIndex(
                name: "IX_categories_removedn",
                table: "categories",
                column: "removedn");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_RecurrenceId",
                table: "transactions",
                column: "RecurrenceId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_accountid",
                table: "transactions",
                column: "accountid");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_addedby",
                table: "transactions",
                column: "addedby");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_addedon",
                table: "transactions",
                column: "addedon");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_categoryid",
                table: "transactions",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_removedn",
                table: "transactions",
                column: "removedn");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_userid",
                table: "transactions",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_users_accountid",
                table: "users",
                column: "accountid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "recurrences");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "accounts");
        }
    }
}
