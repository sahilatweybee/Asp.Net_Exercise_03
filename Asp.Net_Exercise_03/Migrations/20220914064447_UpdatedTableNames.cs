using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Exercise_03.Migrations
{
    public partial class UpdatedTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assign_party_party_party_id",
                table: "assign_party");

            migrationBuilder.DropForeignKey(
                name: "FK_assign_party_product_product_id",
                table: "assign_party");

            migrationBuilder.DropForeignKey(
                name: "FK_rate_product_product_id1",
                table: "rate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rate",
                table: "rate");

            migrationBuilder.DropIndex(
                name: "IX_rate_product_id1",
                table: "rate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_party",
                table: "party");

            migrationBuilder.DropPrimaryKey(
                name: "PK_assign_party",
                table: "assign_party");

            migrationBuilder.DropColumn(
                name: "product_id1",
                table: "rate");

            migrationBuilder.RenameTable(
                name: "rate",
                newName: "Rate_tbl");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Product_tbl");

            migrationBuilder.RenameTable(
                name: "party",
                newName: "Party_tbl");

            migrationBuilder.RenameTable(
                name: "assign_party",
                newName: "Assign_party_tbl");

            migrationBuilder.RenameIndex(
                name: "IX_product_product_name",
                table: "Product_tbl",
                newName: "IX_Product_tbl_product_name");

            migrationBuilder.RenameIndex(
                name: "IX_party_party_name",
                table: "Party_tbl",
                newName: "IX_Party_tbl_party_name");

            migrationBuilder.RenameIndex(
                name: "IX_assign_party_product_id",
                table: "Assign_party_tbl",
                newName: "IX_Assign_party_tbl_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_assign_party_party_id",
                table: "Assign_party_tbl",
                newName: "IX_Assign_party_tbl_party_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rate_tbl",
                table: "Rate_tbl",
                column: "rate_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product_tbl",
                table: "Product_tbl",
                column: "product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Party_tbl",
                table: "Party_tbl",
                column: "party_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assign_party_tbl",
                table: "Assign_party_tbl",
                column: "assign_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_tbl_product_id",
                table: "Rate_tbl",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assign_party_tbl_Party_tbl_party_id",
                table: "Assign_party_tbl",
                column: "party_id",
                principalTable: "Party_tbl",
                principalColumn: "party_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assign_party_tbl_Product_tbl_product_id",
                table: "Assign_party_tbl",
                column: "product_id",
                principalTable: "Product_tbl",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rate_tbl_Product_tbl_product_id",
                table: "Rate_tbl",
                column: "product_id",
                principalTable: "Product_tbl",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assign_party_tbl_Party_tbl_party_id",
                table: "Assign_party_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Assign_party_tbl_Product_tbl_product_id",
                table: "Assign_party_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Rate_tbl_Product_tbl_product_id",
                table: "Rate_tbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rate_tbl",
                table: "Rate_tbl");

            migrationBuilder.DropIndex(
                name: "IX_Rate_tbl_product_id",
                table: "Rate_tbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product_tbl",
                table: "Product_tbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Party_tbl",
                table: "Party_tbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assign_party_tbl",
                table: "Assign_party_tbl");

            migrationBuilder.RenameTable(
                name: "Rate_tbl",
                newName: "rate");

            migrationBuilder.RenameTable(
                name: "Product_tbl",
                newName: "product");

            migrationBuilder.RenameTable(
                name: "Party_tbl",
                newName: "party");

            migrationBuilder.RenameTable(
                name: "Assign_party_tbl",
                newName: "assign_party");

            migrationBuilder.RenameIndex(
                name: "IX_Product_tbl_product_name",
                table: "product",
                newName: "IX_product_product_name");

            migrationBuilder.RenameIndex(
                name: "IX_Party_tbl_party_name",
                table: "party",
                newName: "IX_party_party_name");

            migrationBuilder.RenameIndex(
                name: "IX_Assign_party_tbl_product_id",
                table: "assign_party",
                newName: "IX_assign_party_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_Assign_party_tbl_party_id",
                table: "assign_party",
                newName: "IX_assign_party_party_id");

            migrationBuilder.AddColumn<int>(
                name: "product_id1",
                table: "rate",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_rate",
                table: "rate",
                column: "rate_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_party",
                table: "party",
                column: "party_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assign_party",
                table: "assign_party",
                column: "assign_id");

            migrationBuilder.CreateIndex(
                name: "IX_rate_product_id1",
                table: "rate",
                column: "product_id1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_rate_product_product_id1",
                table: "rate",
                column: "product_id1",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
