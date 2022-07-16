using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ME_Mall.Migrations
{
    public partial class couponB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CardNumber = table.Column<string>(nullable: true),
                    CCV = table.Column<int>(nullable: false),
                    ExpiryMonth = table.Column<int>(nullable: false),
                    ExpiryYear = table.Column<int>(nullable: false),
                    HolderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                    table.ForeignKey(
                       name: "FK_Bank_Holder",
                       column: x => x.HolderId,
                       principalTable: "AspNetUsers",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CouponCode = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
