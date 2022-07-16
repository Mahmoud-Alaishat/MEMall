using Microsoft.EntityFrameworkCore.Migrations;

namespace ME_Mall.Migrations
{
    public partial class balanceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Bank",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Balance",
                table: "Bank",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
