using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Accounting.Persistence.EF.Migrations
{
    public partial class AddTransactionDomainModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<long>(type: "bigint", nullable: true),
                    OwnerType = table.Column<int>(type: "integer", nullable: true),
                    IsRegistered = table.Column<bool>(type: "boolean", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ActionUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<int>(type: "integer", rowVersion: true, nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionItemType = table.Column<int>(type: "integer", nullable: false),
                    TransactionItemReference = table.Column<int>(type: "integer", nullable: false),
                    TransactionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionItems_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionReferences",
                columns: table => new
                {
                    TransactionId = table.Column<long>(type: "bigint", nullable: false),
                    ReferenceId = table.Column<long>(type: "bigint", nullable: false),
                    ActionUserId = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    FormalDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IssuerBranchId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionReferences", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TransactionReferences_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceReferences",
                columns: table => new
                {
                    TransactionId = table.Column<long>(type: "bigint", nullable: false),
                    FeeId = table.Column<long>(type: "bigint", nullable: true),
                    FeeTradingUnitId = table.Column<long>(type: "bigint", nullable: true),
                    SourceTradingUnitId = table.Column<long>(type: "bigint", nullable: false),
                    DestinationTradingUnitId = table.Column<long>(type: "bigint", nullable: false),
                    ReceivableTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Fee = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric", nullable: false),
                    RateReverseCalculation = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceReferences", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_InvoiceReferences_TransactionReferences_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "TransactionReferences",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRequestReferences",
                columns: table => new
                {
                    TransactionId = table.Column<long>(type: "bigint", nullable: false),
                    BusinessPartnerId = table.Column<long>(type: "bigint", nullable: false),
                    TradingUnitId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Fee = table.Column<decimal>(type: "numeric", nullable: false),
                    FeeTradingUnitId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRequestReferences", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_PaymentRequestReferences_TransactionReferences_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "TransactionReferences",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItems_TransactionId",
                table: "TransactionItems",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceReferences");

            migrationBuilder.DropTable(
                name: "PaymentRequestReferences");

            migrationBuilder.DropTable(
                name: "TransactionItems");

            migrationBuilder.DropTable(
                name: "TransactionReferences");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
