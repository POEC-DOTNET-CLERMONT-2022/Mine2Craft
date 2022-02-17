using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class RemoveAnnotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nickname",
                table: "users",
                newName: "Nickname");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "pwd",
                table: "users",
                newName: "Paswword");

            migrationBuilder.RenameColumn(
                name: "isCooked",
                table: "Items",
                newName: "IsCooked");

            migrationBuilder.RenameColumn(
                name: "isCombustible",
                table: "Items",
                newName: "IsCombustible");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "CompleteItems",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "durability",
                table: "CompleteItems",
                newName: "Durability");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "CompleteItems",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "attackPoint",
                table: "CompleteItems",
                newName: "AttackPoint");

            migrationBuilder.RenameColumn(
                name: "armorPoint",
                table: "CompleteItems",
                newName: "ArmorPoint");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CompleteItems",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "complete_item_type",
                table: "CompleteItems",
                newName: "CompleteItemType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "users",
                newName: "nickname");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Paswword",
                table: "users",
                newName: "pwd");

            migrationBuilder.RenameColumn(
                name: "IsCooked",
                table: "Items",
                newName: "isCooked");

            migrationBuilder.RenameColumn(
                name: "IsCombustible",
                table: "Items",
                newName: "isCombustible");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CompleteItems",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Durability",
                table: "CompleteItems",
                newName: "durability");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CompleteItems",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "AttackPoint",
                table: "CompleteItems",
                newName: "attackPoint");

            migrationBuilder.RenameColumn(
                name: "ArmorPoint",
                table: "CompleteItems",
                newName: "armorPoint");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CompleteItems",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CompleteItemType",
                table: "CompleteItems",
                newName: "complete_item_type");
        }
    }
}
