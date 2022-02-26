using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompleteItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durability = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompleteItemType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArmorPoint = table.Column<int>(type: "int", nullable: true),
                    AttackPoint = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompleteItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCombustible = table.Column<byte>(type: "tinyint", nullable: false),
                    IsCooked = table.Column<byte>(type: "tinyint", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Furnaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemBeforeCookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemAfterCookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Furnaces_Items_ItemAfterCookingId",
                        column: x => x.ItemAfterCookingId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Furnaces_Items_ItemBeforeCookingId",
                        column: x => x.ItemBeforeCookingId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Workbenches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    CompleteItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workbenches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workbenches_CompleteItems_CompleteItemId",
                        column: x => x.CompleteItemId,
                        principalTable: "CompleteItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workbenches_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Furnaces_ItemAfterCookingId",
                table: "Furnaces",
                column: "ItemAfterCookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Furnaces_ItemBeforeCookingId",
                table: "Furnaces",
                column: "ItemBeforeCookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workbenches_CompleteItemId",
                table: "Workbenches",
                column: "CompleteItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Workbenches_ItemId",
                table: "Workbenches",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Furnaces");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Workbenches");

            migrationBuilder.DropTable(
                name: "CompleteItems");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
