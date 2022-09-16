using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Exercise_03.Migrations
{
    public partial class Assign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assign_party_party_party_id1",
                table: "assign_party");

            migrationBuilder.DropForeignKey(
                name: "FK_assign_party_product_product_id1",
                table: "assign_party");

            migrationBuilder.DropIndex(
                name: "IX_assign_party_party_id1",
                table: "assign_party");

            migrationBuilder.DropIndex(
                name: "IX_assign_party_product_id1",
                table: "assign_party");

            migrationBuilder.DropColumn(
                name: "party_id1",
                table: "assign_party");

            migrationBuilder.DropColumn(
                name: "product_id1",
                table: "assign_party");

            migrationBuilder.CreateIndex(
                name: "IX_assign_party_party_id",
                table: "assign_party",
                column: "party_id");

            migrationBuilder.CreateIndex(
                name: "IX_assign_party_product_id",
                table: "assign_party",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_assign_party_party_party_id",
                table: "assign_party",
                column: "party_id",
                principalTable: "party",
                principalColumn: "party_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assign_party_product_product_id",
                table: "assign_party",
                column: "product_id",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assign_party_party_party_id",
                table: "assign_party");

            migrationBuilder.DropForeignKey(
                name: "FK_assign_party_product_product_id",
                table: "assign_party");

            migrationBuilder.DropIndex(
                name: "IX_assign_party_party_id",
                table: "assign_party");

            migrationBuilder.DropIndex(
                name: "IX_assign_party_product_id",
                table: "assign_party");

            migrationBuilder.AddColumn<int>(
                name: "party_id1",
                table: "assign_party",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "product_id1",
                table: "assign_party",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_assign_party_party_id1",
                table: "assign_party",
                column: "party_id1");

            migrationBuilder.CreateIndex(
                name: "IX_assign_party_product_id1",
                table: "assign_party",
                column: "product_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_assign_party_party_party_id1",
                table: "assign_party",
                column: "party_id1",
                principalTable: "party",
                principalColumn: "party_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assign_party_product_product_id1",
                table: "assign_party",
                column: "product_id1",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
