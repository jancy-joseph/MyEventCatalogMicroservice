using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCatalogAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "catalog_category_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_location_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "CatalogEventCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Category = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogEventCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogEventLocation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Location = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogEventLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogEventType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogEventType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogEventItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 5000, nullable: false),
                    Description = table.Column<string>(maxLength: 5000, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Schedule = table.Column<DateTime>(nullable: false),
                    PictureUrl = table.Column<string>(maxLength: 100, nullable: true),
                    CatalogCategoryId = table.Column<int>(nullable: false),
                    CatalogTypeId = table.Column<int>(nullable: false),
                    CatalogLocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogEventItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogEventItem_CatalogEventCategory_CatalogCategoryId",
                        column: x => x.CatalogCategoryId,
                        principalTable: "CatalogEventCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogEventItem_CatalogEventLocation_CatalogLocationId",
                        column: x => x.CatalogLocationId,
                        principalTable: "CatalogEventLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogEventItem_CatalogEventType_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalTable: "CatalogEventType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogEventItem_CatalogCategoryId",
                table: "CatalogEventItem",
                column: "CatalogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogEventItem_CatalogLocationId",
                table: "CatalogEventItem",
                column: "CatalogLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogEventItem_CatalogTypeId",
                table: "CatalogEventItem",
                column: "CatalogTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogEventItem");

            migrationBuilder.DropTable(
                name: "CatalogEventCategory");

            migrationBuilder.DropTable(
                name: "CatalogEventLocation");

            migrationBuilder.DropTable(
                name: "CatalogEventType");

            migrationBuilder.DropSequence(
                name: "catalog_category_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_location_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_type_hilo");
        }
    }
}
