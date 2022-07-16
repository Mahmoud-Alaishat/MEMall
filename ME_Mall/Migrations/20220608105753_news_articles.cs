using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ME_Mall.Migrations
{
    public partial class news_articles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsAndArticles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    PostDate = table.Column<DateTime>(nullable: false),
                    WriterId = table.Column<string>(nullable: true),
                    PostImg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsAndArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Article",
                        column: x => x.WriterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsAndArticles");
        }
    }
}
