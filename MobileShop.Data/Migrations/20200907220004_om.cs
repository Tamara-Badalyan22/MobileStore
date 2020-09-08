using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class om : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Phone",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phone_BrandID",
                table: "Phone",
                column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Brand_BrandID",
                table: "Phone",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Brand_BrandID",
                table: "Phone");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Phone_BrandID",
                table: "Phone");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Phone");
        }
    }
}
