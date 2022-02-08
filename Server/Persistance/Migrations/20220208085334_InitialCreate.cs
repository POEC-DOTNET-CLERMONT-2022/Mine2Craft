using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workbenchs_completeItem_CurrentCompleteItemId",
                table: "Workbenchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Workbenchs_Items_CurrentItemId",
                table: "Workbenchs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workbenchs",
                table: "Workbenchs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_completeItem",
                table: "completeItem");

            migrationBuilder.RenameTable(
                name: "Workbenchs",
                newName: "Workbenches");

            migrationBuilder.RenameTable(
                name: "completeItem",
                newName: "CompleteItems");

            migrationBuilder.RenameColumn(
                name: "CurrentItemId",
                table: "Workbenches",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "CurrentCompleteItemId",
                table: "Workbenches",
                newName: "CompleteItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Workbenchs_CurrentItemId",
                table: "Workbenches",
                newName: "IX_Workbenches_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Workbenchs_CurrentCompleteItemId",
                table: "Workbenches",
                newName: "IX_Workbenches_CompleteItemId");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Workbenches",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "CompleteItems",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<int>(
                name: "armorPoint",
                table: "CompleteItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "attackPoint",
                table: "CompleteItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "complete_item_type",
                table: "CompleteItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workbenches",
                table: "Workbenches",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Workbenches_Items_ItemId",
                table: "Workbenches",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workbenches_CompleteItems_CompleteItemId",
                table: "Workbenches");

            migrationBuilder.DropForeignKey(
                name: "FK_Workbenches_Items_ItemId",
                table: "Workbenches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workbenches",
                table: "Workbenches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompleteItems",
                table: "CompleteItems");

            migrationBuilder.DropColumn(
                name: "armorPoint",
                table: "CompleteItems");

            migrationBuilder.DropColumn(
                name: "attackPoint",
                table: "CompleteItems");

            migrationBuilder.DropColumn(
                name: "complete_item_type",
                table: "CompleteItems");

            migrationBuilder.RenameTable(
                name: "Workbenches",
                newName: "Workbenchs");

            migrationBuilder.RenameTable(
                name: "CompleteItems",
                newName: "completeItem");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Workbenchs",
                newName: "CurrentItemId");

            migrationBuilder.RenameColumn(
                name: "CompleteItemId",
                table: "Workbenchs",
                newName: "CurrentCompleteItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Workbenches_ItemId",
                table: "Workbenchs",
                newName: "IX_Workbenchs_CurrentItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Workbenches_CompleteItemId",
                table: "Workbenchs",
                newName: "IX_Workbenchs_CurrentCompleteItemId");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Workbenchs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "completeItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workbenchs",
                table: "Workbenchs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_completeItem",
                table: "completeItem",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workbenchs_completeItem_CurrentCompleteItemId",
                table: "Workbenchs",
                column: "CurrentCompleteItemId",
                principalTable: "completeItem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workbenchs_Items_CurrentItemId",
                table: "Workbenchs",
                column: "CurrentItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
