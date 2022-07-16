using Microsoft.EntityFrameworkCore.Migrations;

namespace ME_Mall.Migrations
{
    public partial class contactUs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contactUs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactUs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contactUs");
        }
    }
}
