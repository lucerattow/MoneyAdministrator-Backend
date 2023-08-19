using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoneyAdministratorBackend.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CreditCardBrands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CreditCardBrands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Salaries",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EntityTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "EntityTypes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Entities",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CurrencyValues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "LastFourNumbers",
                table: "CreditCards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CreditCards",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CreditCardBrands",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_UserId",
                table: "Salaries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityTypes_UserId",
                table: "EntityTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_UserId",
                table: "Entities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyValues_UserId",
                table: "CurrencyValues",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_UserId",
                table: "CreditCards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCards_User_UserId",
                table: "CreditCards",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyValues_User_UserId",
                table: "CurrencyValues",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_User_UserId",
                table: "Entities",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityTypes_User_UserId",
                table: "EntityTypes",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_User_UserId",
                table: "Salaries",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_User_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCards_User_UserId",
                table: "CreditCards");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyValues_User_UserId",
                table: "CurrencyValues");

            migrationBuilder.DropForeignKey(
                name: "FK_Entities_User_UserId",
                table: "Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityTypes_User_UserId",
                table: "EntityTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_User_UserId",
                table: "Salaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_User_UserId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_UserId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_EntityTypes_UserId",
                table: "EntityTypes");

            migrationBuilder.DropIndex(
                name: "IX_Entities_UserId",
                table: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_CurrencyValues_UserId",
                table: "CurrencyValues");

            migrationBuilder.DropIndex(
                name: "IX_CreditCards_UserId",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EntityTypes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CurrencyValues");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CreditCards");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EntityTypes",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Currencies",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LastFourNumbers",
                table: "CreditCards",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CreditCardBrands",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "CreditCardBrands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Visa" },
                    { 2, "MasterCard" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ARS" },
                    { 2, "USD" }
                });

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "Deleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "General" },
                    { 2, false, "Banco" }
                });
        }
    }
}
