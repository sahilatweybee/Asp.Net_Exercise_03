using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Exercise_03.Migrations
{
    public partial class UpdatedRateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rate_tbl_Product_id",
                table: "Rate_tbl");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_tbl_Product_id",
                table: "Rate_tbl",
                column: "Product_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rate_tbl_Product_id",
                table: "Rate_tbl");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_tbl_Product_id",
                table: "Rate_tbl",
                column: "Product_id");
        }
    }
}
