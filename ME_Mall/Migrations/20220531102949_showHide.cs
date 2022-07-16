using Microsoft.EntityFrameworkCore.Migrations;

namespace ME_Mall.Migrations
{
    public partial class showHide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ShowHide",
                table: "contactUs",
                nullable: false,
                defaultValue: (byte)1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowHide",
                table: "contactUs");
        }
    }
}
