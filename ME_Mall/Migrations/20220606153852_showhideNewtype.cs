using Microsoft.EntityFrameworkCore.Migrations;

namespace ME_Mall.Migrations
{
    public partial class showhideNewtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShowHide",
                table: "contactUs",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "NUMBER(3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "ShowHide",
                table: "contactUs",
                type: "NUMBER(3)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
