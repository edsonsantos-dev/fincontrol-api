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
                    addedon = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    addedby = table.Column<Guid>(type: "uuid", nullable: false),
                    modifiedon = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    modifiedby = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recurrences",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    installment = table.Column<int>(type: "integer", nullable: false),
                    frequency = table.Column<int>(type: "integer", nullable: false),
                    addedon = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    addedby = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recurrences", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    passwordhash = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    whatsappnumber = table.Column<string>(type: "text", nullable: true),
                    confirmedwhatsappnumber = table.Column<bool>(type: "boolean", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    accountid = table.Column<Guid>(type: "uuid", nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false),
                    addedon = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    addedby = table.Column<Guid>(type: "uuid", nullable: false),
                    modifiedon = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    modifiedby = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_accounts_accountid",
                        column: x => x.accountid,
                        principalTable: "accounts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    accountid = table.Column<Guid>(type: "uuid", nullable: false),
                    addedon = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    addedby = table.Column<Guid>(type: "uuid", nullable: false),
                    modifiedon = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    modifiedby = table.Column<Guid>(type: "uuid", nullable: true),
                    removedon = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removedby = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                    table.ForeignKey(
                        name: "fk_categories_accounts_accountid",
                        column: x => x.accountid,
                        principalTable: "accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_categories_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    installment = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    categoryid = table.Column<Guid>(type: "uuid", nullable: false),
                    recurrenceid = table.Column<Guid>(type: "uuid", nullable: true),
                    accountid = table.Column<Guid>(type: "uuid", nullable: false),
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    addedon = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    addedby = table.Column<Guid>(type: "uuid", nullable: false),
                    modifiedon = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    modifiedby = table.Column<Guid>(type: "uuid", nullable: true),
                    removedon = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removedby = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_transactions_accounts_accountid",
                        column: x => x.accountid,
                        principalTable: "accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_transactions_categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_transactions_recurrence_recurrenceid",
                        column: x => x.recurrenceid,
                        principalTable: "recurrences",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_transactions_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_categories_accountid",
                table: "categories",
                column: "accountid");

            migrationBuilder.CreateIndex(
                name: "ix_categories_addedby",
                table: "categories",
                column: "addedby");

            migrationBuilder.CreateIndex(
                name: "ix_categories_addedon",
                table: "categories",
                column: "addedon");

            migrationBuilder.CreateIndex(
                name: "ix_categories_isactive",
                table: "categories",
                column: "isactive");

            migrationBuilder.CreateIndex(
                name: "ix_categories_removedon",
                table: "categories",
                column: "removedon");

            migrationBuilder.CreateIndex(
                name: "ix_categories_userid",
                table: "categories",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_transactions_accountid",
                table: "transactions",
                column: "accountid");

            migrationBuilder.CreateIndex(
                name: "ix_transactions_addedby",
                table: "transactions",
                column: "addedby");

            migrationBuilder.CreateIndex(
                name: "ix_transactions_addedon",
                table: "transactions",
                column: "addedon");

            migrationBuilder.CreateIndex(
                name: "ix_transactions_categoryid",
                table: "transactions",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_transactions_recurrenceid",
                table: "transactions",
                column: "recurrenceid");

            migrationBuilder.CreateIndex(
                name: "ix_transactions_removedon",
                table: "transactions",
                column: "removedon");

            migrationBuilder.CreateIndex(
                name: "ix_transactions_userid",
                table: "transactions",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_users_accountid",
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
