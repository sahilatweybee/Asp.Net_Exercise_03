using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Exercise_03.Migrations
{
    public partial class UpdatedColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Rate_tbl_product_id",
                table: "Rate_tbl");

            migrationBuilder.DropIndex(
                name: "IX_Product_tbl_product_name",
                table: "Product_tbl");

            migrationBuilder.DropIndex(
                name: "IX_Party_tbl_party_name",
                table: "Party_tbl");

            migrationBuilder.DropIndex(
                name: "IX_Assign_party_tbl_party_id",
                table: "Assign_party_tbl");

            migrationBuilder.DropIndex(
                name: "IX_Assign_party_tbl_product_id",
                table: "Assign_party_tbl");

            migrationBuilder.DropColumn(
                name: "rate",
                table: "Rate_tbl");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Rate_tbl",
                newName: "Product_id");

            migrationBuilder.RenameColumn(
                name: "date_of_rate",
                table: "Rate_tbl",
                newName: "Date_of_Rate");

            migrationBuilder.RenameColumn(
                name: "rate_id",
                table: "Rate_tbl",
                newName: "Rate_id");

            migrationBuilder.RenameColumn(
                name: "product_name",
                table: "Product_tbl",
                newName: "Product_name");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Product_tbl",
                newName: "Product_id");

            migrationBuilder.RenameColumn(
                name: "party_name",
                table: "Party_tbl",
                newName: "Party_name");

            migrationBuilder.RenameColumn(
                name: "party_id",
                table: "Party_tbl",
                newName: "Party_id");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Assign_party_tbl",
                newName: "Product_id");

            migrationBuilder.RenameColumn(
                name: "party_id",
                table: "Assign_party_tbl",
                newName: "Party_id");

            migrationBuilder.RenameColumn(
                name: "assign_id",
                table: "Assign_party_tbl",
                newName: "Assign_id");

            migrationBuilder.AddColumn<int>(
                name: "Product_id1",
                table: "Rate_tbl",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Product_rate",
                table: "Rate_tbl",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Party_id1",
                table: "Assign_party_tbl",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Product_id1",
                table: "Assign_party_tbl",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rate_tbl_Product_id1",
                table: "Rate_tbl",
                column: "Product_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_tbl_Product_name",
                table: "Product_tbl",
                column: "Product_name",
                unique: true,
                filter: "[Product_name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Party_tbl_Party_name",
                table: "Party_tbl",
                column: "Party_name",
                unique: true,
                filter: "[Party_name] IS NOT NULL");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IX_Product_tbl_Product_name",
                table: "Product_tbl");

            migrationBuilder.DropIndex(
                name: "IX_Party_tbl_Party_name",
                table: "Party_tbl");

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
                name: "Product_rate",
                table: "Rate_tbl");

            migrationBuilder.DropColumn(
                name: "Party_id1",
                table: "Assign_party_tbl");

            migrationBuilder.DropColumn(
                name: "Product_id1",
                table: "Assign_party_tbl");

            migrationBuilder.RenameColumn(
                name: "Product_id",
                table: "Rate_tbl",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "Date_of_Rate",
                table: "Rate_tbl",
                newName: "date_of_rate");

            migrationBuilder.RenameColumn(
                name: "Rate_id",
                table: "Rate_tbl",
                newName: "rate_id");

            migrationBuilder.RenameColumn(
                name: "Product_name",
                table: "Product_tbl",
                newName: "product_name");

            migrationBuilder.RenameColumn(
                name: "Product_id",
                table: "Product_tbl",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "Party_name",
                table: "Party_tbl",
                newName: "party_name");

            migrationBuilder.RenameColumn(
                name: "Party_id",
                table: "Party_tbl",
                newName: "party_id");

            migrationBuilder.RenameColumn(
                name: "Product_id",
                table: "Assign_party_tbl",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "Party_id",
                table: "Assign_party_tbl",
                newName: "party_id");

            migrationBuilder.RenameColumn(
                name: "Assign_id",
                table: "Assign_party_tbl",
                newName: "assign_id");

            migrationBuilder.AddColumn<int>(
                name: "rate",
                table: "Rate_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rate_tbl_product_id",
                table: "Rate_tbl",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_tbl_product_name",
                table: "Product_tbl",
                column: "product_name",
                unique: true,
                filter: "[product_name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Party_tbl_party_name",
                table: "Party_tbl",
                column: "party_name",
                unique: true,
                filter: "[party_name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Assign_party_tbl_party_id",
                table: "Assign_party_tbl",
                column: "party_id");

            migrationBuilder.CreateIndex(
                name: "IX_Assign_party_tbl_product_id",
                table: "Assign_party_tbl",
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
    }
}
