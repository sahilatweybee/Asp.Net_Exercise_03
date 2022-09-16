using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Exercise_03.Migrations
{
    public partial class AddedAssign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rate_product_product_id",
                table: "rate");

            migrationBuilder.DropIndex(
                name: "IX_rate_product_id",
                table: "rate");

            migrationBuilder.AlterColumn<int>(
                name: "product_id",
                table: "rate",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "product_id1",
                table: "rate",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_rate_product_id1",
                table: "rate",
                column: "product_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_rate_product_product_id1",
                table: "rate",
                column: "product_id1",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rate_product_product_id1",
                table: "rate");

            migrationBuilder.DropIndex(
                name: "IX_rate_product_id1",
                table: "rate");

            migrationBuilder.DropColumn(
                name: "product_id1",
                table: "rate");

            migrationBuilder.AlterColumn<int>(
                name: "product_id",
                table: "rate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_rate_product_id",
                table: "rate",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_rate_product_product_id",
                table: "rate",
                column: "product_id",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
