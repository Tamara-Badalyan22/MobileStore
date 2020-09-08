using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class change2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Phone",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.DropIndex(
                name: "IX_Phone_BrandID",
                table: "Phone");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Phone");
        }
    }
}
