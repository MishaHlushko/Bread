using Microsoft.EntityFrameworkCore.Migrations;

namespace Beads_Store.Migrations
{
    public partial class UpdateBeads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beads_mICategories_MICategoryId",
                table: "Beads");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Beads");

            migrationBuilder.AlterColumn<int>(
                name: "MICategoryId",
                table: "Beads",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Beads_mICategories_MICategoryId",
                table: "Beads",
                column: "MICategoryId",
                principalTable: "mICategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beads_mICategories_MICategoryId",
                table: "Beads");

            migrationBuilder.AlterColumn<int>(
                name: "MICategoryId",
                table: "Beads",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Beads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Beads_mICategories_MICategoryId",
                table: "Beads",
                column: "MICategoryId",
                principalTable: "mICategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
