using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Persistence.EF.Migrations
{
    public partial class AddDetailedAccountIdToVoucherItemAccountTemplateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Account_Id",
                table: "VoucherItems",
                newName: "SubsidiaryAccountId");

            migrationBuilder.AddColumn<long>(
                name: "DetailedAccountId",
                table: "VoucherItems",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailedAccountId",
                table: "VoucherItems");

            migrationBuilder.RenameColumn(
                name: "SubsidiaryAccountId",
                table: "VoucherItems",
                newName: "Account_Id");
        }
    }
}
