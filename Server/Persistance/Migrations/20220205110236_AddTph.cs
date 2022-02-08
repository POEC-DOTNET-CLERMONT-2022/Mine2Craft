using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddTph : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workbenches_Tools_CompleteItemId",
                table: "Workbenches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tools",
                table: "Tools");

            migrationBuilder.RenameTable(
                name: "Tools",
                newName: "CompleteItems");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CompleteItems",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "attackPoint",
                table: "CompleteItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CompleteItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompleteItems",
                table: "CompleteItems",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workbenches_CompleteItems_CompleteItemId",
                table: "Workbenches",
                column: "CompleteItemId",
                principalTable: "CompleteItems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workbenches_CompleteItems_CompleteItemId",
                table: "Workbenches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompleteItems",
                table: "CompleteItems");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CompleteItems");

            migrationBuilder.RenameTable(
                name: "CompleteItems",
                newName: "Tools");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tools",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "attackPoint",
                table: "Tools",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tools",
                table: "Tools",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workbenches_Tools_CompleteItemId",
                table: "Workbenches",
                column: "CompleteItemId",
                principalTable: "Tools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
