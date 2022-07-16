using Microsoft.EntityFrameworkCore.Migrations;

namespace ME_Mall.Migrations
{
    public partial class prodNameClo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "OrderProduct",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "OrderProduct");
        }
    }
}
