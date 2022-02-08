using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class TryInheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
