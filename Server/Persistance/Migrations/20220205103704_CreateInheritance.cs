using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class CreateInheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workbenches_completeItem_CompleteItemId",
                table: "Workbenches");

            migrationBuilder.DropTable(
                name: "completeItem");

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durability = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    attackPoint = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Workbenches_Tools_CompleteItemId",
                table: "Workbenches",
                column: "CompleteItemId",
                principalTable: "Tools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workbenches_Tools_CompleteItemId",
                table: "Workbenches");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.CreateTable(
                name: "completeItem",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    durability = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_completeItem", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Workbenches_completeItem_CompleteItemId",
                table: "Workbenches",
                column: "CompleteItemId",
                principalTable: "completeItem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
