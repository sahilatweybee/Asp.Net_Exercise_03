using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Exercise_03.Migrations
{
    public partial class AddedUniqueConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "party_Id",
                table: "party",
                newName: "party_id");

            migrationBuilder.AlterColumn<string>(
                name: "party_name",
                table: "party",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "assign_party",
                columns: table => new
                {
                    assign_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    party_id = table.Column<int>(nullable: true),
                    product_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assign_party", x => x.assign_id);
                    table.ForeignKey(
                        name: "FK_assign_party_party_party_id",
                        column: x => x.party_id,
                        principalTable: "party",
                        principalColumn: "party_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_assign_party_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rate",
                columns: table => new
                {
                    rate_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(nullable: true),
                    date_of_rate = table.Column<DateTime>(nullable: false),
                    rate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rate", x => x.rate_id);
                    table.ForeignKey(
                        name: "FK_rate_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_party_party_name",
                table: "party",
                column: "party_name",
                unique: true,
                filter: "[party_name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_assign_party_party_id",
                table: "assign_party",
                column: "party_id");

            migrationBuilder.CreateIndex(
                name: "IX_assign_party_product_id",
                table: "assign_party",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_product_name",
                table: "product",
                column: "product_name",
                unique: true,
                filter: "[product_name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_rate_product_id",
                table: "rate",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assign_party");

            migrationBuilder.DropTable(
                name: "rate");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropIndex(
                name: "IX_party_party_name",
                table: "party");

            migrationBuilder.RenameColumn(
                name: "party_id",
                table: "party",
                newName: "party_Id");

            migrationBuilder.AlterColumn<string>(
                name: "party_name",
                table: "party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
