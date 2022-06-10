using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Persistence.EF.Migrations
{
    public partial class AddFloatAccountGroupDomainModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "FloatAccountGroupSeq");

            migrationBuilder.CreateTable(
                name: "FloatAccountGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    FloatAccountId = table.Column<long>(type: "bigint", nullable: false),
                    AccountGroupId = table.Column<long>(type: "bigint", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ActionUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<int>(type: "integer", rowVersion: true, nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloatAccountGroups", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FloatAccountGroups");

            migrationBuilder.DropSequence(
                name: "FloatAccountGroupSeq");
        }
    }
}
