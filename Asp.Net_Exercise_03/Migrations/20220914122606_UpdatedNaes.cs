using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Exercise_03.Migrations
{
    public partial class UpdatedNaes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assign_party_tbl_Party_tbl_Party_id1",
                table: "Assign_party_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Assign_party_tbl_Product_tbl_Product_id1",
                table: "Assign_party_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Rate_tbl_Product_tbl_Product_id1",
                table: "Rate_tbl");

            migrationBuilder.DropIndex(
                name: "IX_Rate_tbl_Product_id1",
                table: "Rate_tbl");

            migrationBuilder.DropIndex(
                name: "IX_Assign_party_tbl_Party_id1",
                table: "Assign_party_tbl");

            migrationBuilder.DropIndex(
                name: "IX_Assign_party_tbl_Product_id1",
                table: "Assign_party_tbl");

            migrationBuilder.DropColumn(
                name: "Product_id1",
                table: "Rate_tbl");

            migrationBuilder.DropColumn(
                name: "Party_id1",
                table: "Assign_party_tbl");

            migrationBuilder.DropColumn(
                name: "Product_id1",
                table: "Assign_party_tbl");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_tbl_Product_id",
                table: "Rate_tbl",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Assign_party_tbl_Party_id",
                table: "Assign_party_tbl",
                column: "Party_id");

            migrationBuilder.CreateIndex(
                name: "IX_Assign_party_tbl_Product_id",
                table: "Assign_party_tbl",
                column: "Product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assign_party_tbl_Party_tbl_Party_id",
                table: "Assign_party_tbl",
                column: "Party_id",
                principalTable: "Party_tbl",
                principalColumn: "Party_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assign_party_tbl_Product_tbl_Product_id",
                table: "Assign_party_tbl",
                column: "Product_id",
                principalTable: "Product_tbl",
                principalColumn: "Product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rate_tbl_Product_tbl_Product_id",
                table: "Rate_tbl",
                column: "Product_id",
                principalTable: "Product_tbl",
                principalColumn: "Product_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assign_party_tbl_Party_tbl_Party_id",
                table: "Assign_party_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Assign_party_tbl_Product_tbl_Product_id",
                table: "Assign_party_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Rate_tbl_Product_tbl_Product_id",
                table: "Rate_tbl");

            migrationBuilder.DropIndex(
                name: "IX_Rate_tbl_Product_id",
                table: "Rate_tbl");

            migrationBuilder.DropIndex(
                name: "IX_Assign_party_tbl_Party_id",
                table: "Assign_party_tbl");

            migrationBuilder.DropIndex(
                name: "IX_Assign_party_tbl_Product_id",
                table: "Assign_party_tbl");

            migrationBuilder.AddColumn<int>(
                name: "Product_id1",
                table: "Rate_tbl",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Party_id1",
                table: "Assign_party_tbl",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Product_id1",
                table: "Assign_party_tbl",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rate_tbl_Product_id1",
                table: "Rate_tbl",
                column: "Product_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Assign_party_tbl_Party_id1",
                table: "Assign_party_tbl",
                column: "Party_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Assign_party_tbl_Product_id1",
                table: "Assign_party_tbl",
                column: "Product_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Assign_party_tbl_Party_tbl_Party_id1",
                table: "Assign_party_tbl",
                column: "Party_id1",
                principalTable: "Party_tbl",
                principalColumn: "Party_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assign_party_tbl_Product_tbl_Product_id1",
                table: "Assign_party_tbl",
                column: "Product_id1",
                principalTable: "Product_tbl",
                principalColumn: "Product_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rate_tbl_Product_tbl_Product_id1",
                table: "Rate_tbl",
                column: "Product_id1",
                principalTable: "Product_tbl",
                principalColumn: "Product_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
