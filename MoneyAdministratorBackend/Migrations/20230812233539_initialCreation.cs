using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoneyAdministratorBackend.Migrations
{
    /// <inheritdoc />
    public partial class initialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCardBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyValues_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salaries_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entities_EntityTypes_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "EntityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    CreditCardBrandId = table.Column<int>(type: "int", nullable: false),
                    LastFourNumbers = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCards_CreditCardBrands_CreditCardBrandId",
                        column: x => x.CreditCardBrandId,
                        principalTable: "CreditCardBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditCards_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    TransactionPayId = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateNext = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateNextExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalArs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinimumPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Imported = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCardSummaries_CreditCards_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "CreditCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditCardSummaries_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    Concider = table.Column<bool>(type: "bit", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionDetails_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardSummaryDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardSummaryId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Installments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountArs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardSummaryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCardSummaryDetails_CreditCardSummaries_CreditCardSummaryId",
                        column: x => x.CreditCardSummaryId,
                        principalTable: "CreditCardSummaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_CreditCardBrandId",
                table: "CreditCards",
                column: "CreditCardBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_EntityId",
                table: "CreditCards",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardSummaries_CreditCardId",
                table: "CreditCardSummaries",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardSummaries_TransactionId",
                table: "CreditCardSummaries",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardSummaryDetails_CreditCardSummaryId",
                table: "CreditCardSummaryDetails",
                column: "CreditCardSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyValues_CurrencyId",
                table: "CurrencyValues",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_EntityTypeId",
                table: "Entities",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_CurrencyId",
                table: "Salaries",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_TransactionId",
                table: "TransactionDetails",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CurrencyId",
                table: "Transactions",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EntityId",
                table: "Transactions",
                column: "EntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCardSummaryDetails");

            migrationBuilder.DropTable(
                name: "CurrencyValues");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "TransactionDetails");

            migrationBuilder.DropTable(
                name: "CreditCardSummaries");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "CreditCardBrands");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "EntityTypes");
        }
    }
}
