using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Exercise_03.Migrations
{
    public partial class AddedAssignParty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "product_id",
                table: "assign_party",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "party_id",
                table: "assign_party",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "party_id1",
                table: "assign_party",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "product_id1",
                table: "assign_party",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "product_id",
                table: "assign_party",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "party_id",
                table: "assign_party",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assign_party_product_product_id",
                table: "assign_party",
                column: "product_id",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
