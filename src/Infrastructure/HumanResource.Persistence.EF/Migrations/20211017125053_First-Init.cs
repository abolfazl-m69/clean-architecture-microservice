using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Accounting.Persistence.EF.Migrations
{
    public partial class FirstInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "AccountSeq");

            migrationBuilder.CreateSequence(
                name: "BankBranchSeq");

            migrationBuilder.CreateSequence(
                name: "BankSeq");

            migrationBuilder.CreateSequence(
                name: "BranchSeq");

            migrationBuilder.CreateSequence(
                name: "CostCenterSeq");

            migrationBuilder.CreateSequence(
                name: "FiscalYearSeq");

            migrationBuilder.CreateSequence(
                name: "FloatAccountSeq");

            migrationBuilder.CreateSequence(
                name: "VoucherSeq");

            migrationBuilder.CreateTable(
                name: "accountingprocessedmessages",
                columns: table => new
                {
                    eventid = table.Column<Guid>(type: "UUID", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountingprocessedmessages", x => x.eventid);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    EnglishName = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<int>(type: "integer", nullable: false),
                    AccountNature = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AccountDiscriminator = table.Column<string>(type: "text", nullable: false),
                    AccountType = table.Column<int>(type: "integer", nullable: true),
                    SubsidiaryAccountId = table.Column<long>(type: "bigint", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    AccountGroupId = table.Column<long>(type: "bigint", nullable: true),
                    GeneralAccountId = table.Column<long>(type: "bigint", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ActionUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<int>(type: "integer", rowVersion: true, nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EventName = table.Column<string>(type: "text", nullable: true),
                    PersianName = table.Column<string>(type: "text", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ActionUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<int>(type: "integer", rowVersion: true, nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankBranches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BankId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EnglishName = table.Column<string>(type: "text", nullable: false),
                    BranchCode = table.Column<string>(type: "text", nullable: false),
                    SwiftCode = table.Column<string>(type: "text", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    CityName = table.Column<string>(type: "text", nullable: true),
                    Tell = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ActionUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<int>(type: "integer", rowVersion: true, nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EnglishName = table.Column<string>(type: "text", nullable: false),
                    BranchCode = table.Column<string>(type: "text", nullable: false),
                    SwiftCode = table.Column<string>(type: "text", nullable: true),
                    WebSiteUrl = table.Column<string>(type: "text", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ActionUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<int>(type: "integer", rowVersion: true, nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EnglishName = table.Column<string>(type: "text", nullable: false),
                    IsCentralBranch = table.Column<bool>(type: "boolean", nullable: false),
                    AbbreviationChar = table.Column<string>(type: "text", nullable: true),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    UseGregorianCalendar = table.Column<bool>(type: "boolean", nullable: false),
                    ExternalSystemId = table.Column<long>(type: "bigint", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ActionUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<int>(type: "integer", rowVersion: true, nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostCenters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EnglishName = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ActionUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<int>(type: "integer", rowVersion: true, nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FiscalYears",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    EnglishName = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ActionUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<int>(type: "integer", rowVersion: true, nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FloatAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    EnglishName = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<int>(type: "integer", nullable: false),
                    Budget = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ParentFloatAccountId = table.Column<long>(type: "bigint", nullable: true),
                    AccountReferenceType = table.Column<int>(type: "integer", nullable: true),
                    AccountReferenceId = table.Column<long>(type: "bigint", nullable: true),
                    LegacyAccountSystemReferenceId = table.Column<string>(type: "text", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ActionUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<int>(type: "integer", rowVersion: true, nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloatAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradingUnits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LegacyId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    EnglishName = table.Column<string>(type: "text", nullable: false),
                    TradingUnitType = table.Column<int>(type: "integer", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ActionUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<int>(type: "integer", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    VoucherTypeId = table.Column<long>(type: "bigint", nullable: false),
                    FormalDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IssuedBranchId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DisplayOrder = table.Column<long>(type: "bigint", nullable: false),
                    ApprovementUserId = table.Column<long>(type: "bigint", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ActionUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<int>(type: "integer", rowVersion: true, nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountTemplateItems",
                columns: table => new
                {
                    AccountTemplateId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeOfDebitCredit = table.Column<int>(type: "integer", nullable: false),
                    Account_Id = table.Column<long>(type: "bigint", nullable: false),
                    PropertyInfo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTemplateItems", x => new { x.AccountTemplateId, x.Id });
                    table.ForeignKey(
                        name: "FK_AccountTemplateItems_AccountTemplates_AccountTemplateId",
                        column: x => x.AccountTemplateId,
                        principalTable: "AccountTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoucherItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeOfDebitCredit = table.Column<int>(type: "integer", nullable: true),
                    Account_Id = table.Column<long>(type: "bigint", nullable: true),
                    FloatAccountId = table.Column<long>(type: "bigint", nullable: true),
                    DebitAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    CreditAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    ExchangeDebitAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    ExchangeCreditAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    ReferenceType = table.Column<int>(type: "integer", nullable: true),
                    ReferenceId = table.Column<long>(type: "bigint", nullable: true),
                    TradingUnitId = table.Column<long>(type: "bigint", nullable: false),
                    BranchTradingUnitId = table.Column<long>(type: "bigint", nullable: false),
                    DisplayOrder = table.Column<long>(type: "bigint", nullable: false),
                    FirstCostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    SecondCostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    VoucherId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoucherItems_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoucherStatuses",
                columns: table => new
                {
                    VoucherId = table.Column<long>(type: "bigint", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherStatuses", x => x.VoucherId);
                    table.ForeignKey(
                        name: "FK_VoucherStatuses_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoucherItems_VoucherId",
                table: "VoucherItems",
                column: "VoucherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accountingprocessedmessages");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountTemplateItems");

            migrationBuilder.DropTable(
                name: "BankBranches");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "CostCenters");

            migrationBuilder.DropTable(
                name: "FiscalYears");

            migrationBuilder.DropTable(
                name: "FloatAccounts");

            migrationBuilder.DropTable(
                name: "TradingUnits");

            migrationBuilder.DropTable(
                name: "VoucherItems");

            migrationBuilder.DropTable(
                name: "VoucherStatuses");

            migrationBuilder.DropTable(
                name: "AccountTemplates");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropSequence(
                name: "AccountSeq");

            migrationBuilder.DropSequence(
                name: "BankBranchSeq");

            migrationBuilder.DropSequence(
                name: "BankSeq");

            migrationBuilder.DropSequence(
                name: "BranchSeq");

            migrationBuilder.DropSequence(
                name: "CostCenterSeq");

            migrationBuilder.DropSequence(
                name: "FiscalYearSeq");

            migrationBuilder.DropSequence(
                name: "FloatAccountSeq");

            migrationBuilder.DropSequence(
                name: "VoucherSeq");
        }
    }
}
