using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddPropertyDiscriminator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "CompleteItems",
                newName: "complete_item_type");

            migrationBuilder.AddColumn<string>(
                name: "complete_item_type1",
                table: "CompleteItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "complete_item_type1",
                table: "CompleteItems");

            migrationBuilder.RenameColumn(
                name: "complete_item_type",
                table: "CompleteItems",
                newName: "Discriminator");
        }
    }
}
