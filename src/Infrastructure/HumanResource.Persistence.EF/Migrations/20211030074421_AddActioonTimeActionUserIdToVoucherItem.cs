using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Persistence.EF.Migrations
{
    public partial class AddActioonTimeActionUserIdToVoucherItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "TransactionSeq");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActionTime",
                table: "VoucherItems",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ActionUserId",
                table: "VoucherItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "TransactionSeq");

            migrationBuilder.DropColumn(
                name: "ActionTime",
                table: "VoucherItems");

            migrationBuilder.DropColumn(
                name: "ActionUserId",
                table: "VoucherItems");
        }
    }
}
