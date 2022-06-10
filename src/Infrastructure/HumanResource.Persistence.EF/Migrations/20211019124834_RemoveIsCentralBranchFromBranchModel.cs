using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Persistence.EF.Migrations
{
    public partial class RemoveIsCentralBranchFromBranchModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCentralBranch",
                table: "Branches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCentralBranch",
                table: "Branches",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
