using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Persistence.EF.Migrations
{
    public partial class AddDetailedAccountIdToAccountTemplateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Account_Id",
                table: "AccountTemplateItems",
                newName: "SubsidiaryAccountId");

            migrationBuilder.AddColumn<long>(
                name: "DetailedAccountId",
                table: "AccountTemplateItems",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailedAccountId",
                table: "AccountTemplateItems");

            migrationBuilder.RenameColumn(
                name: "SubsidiaryAccountId",
                table: "AccountTemplateItems",
                newName: "Account_Id");
        }
    }
}
