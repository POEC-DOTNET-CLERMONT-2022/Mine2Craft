using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class FixPropertyDiscriminator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "complete_item_type1",
                table: "CompleteItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "complete_item_type1",
                table: "CompleteItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
