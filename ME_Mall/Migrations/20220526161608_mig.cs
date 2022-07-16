using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ME_Mall.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(nullable: true),
                    ProductImage = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Units",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Store_Catt",
                        column: x => x.CategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });
            migrationBuilder.CreateTable(
               name: "ProductStore",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                   productId = table.Column<int>(nullable: false),
                   storeId = table.Column<int>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_ProductStore", x => x.Id);
                   table.ForeignKey(
                       name: "FK_Prod_Sto",
                       column: x => x.productId,
                       principalTable: "Products",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_Store_Ord",
                       column: x => x.storeId,
                       principalTable: "Stores",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
               });
            migrationBuilder.CreateTable(
               name: "OrderProduct",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                   OrderId = table.Column<int>(nullable: false),
                   ProductId = table.Column<int>(nullable: false),
                   Quantity = table.Column<int>(nullable: false),
                   Value = table.Column<decimal>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_OrderProduct", x => x.Id);
                   table.ForeignKey(
                       name: "FK_Order_User",
                       column: x => x.OrderId,
                       principalTable: "Orders",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_Product_User",
                       column: x => x.ProductId,
                       principalTable: "Products",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.SetNull);
               });
            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitId",
                table: "Products",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Design");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductStore");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
