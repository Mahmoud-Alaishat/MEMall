using Microsoft.EntityFrameworkCore.Migrations;

namespace ME_Mall.Migrations
{
    public partial class couponBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
             name: "Notes",
             table: "Orders",
             nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryId",
                table: "Orders",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Deliv",
                table: "Orders",
                column: "DeliveryId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Orders");
        }
    }
}
