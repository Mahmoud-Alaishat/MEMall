using Microsoft.EntityFrameworkCore.Migrations;

namespace ME_Mall.Migrations
{
    public partial class holderNamecol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HolderName",
                table: "Bank",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HolderName",
                table: "Bank");
        }
    }
}
