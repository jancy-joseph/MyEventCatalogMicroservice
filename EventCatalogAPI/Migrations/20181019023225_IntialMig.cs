using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class IntialMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "event_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_topic_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "EventTopic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Topic = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTopic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: false),
                    StartDate = table.Column<string>(maxLength: 50, nullable: false),
                    EndDate = table.Column<string>(maxLength: 50, nullable: false),
                    StartTime = table.Column<string>(nullable: true),
                    EndTime = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Organizer = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    EventTypeId = table.Column<int>(nullable: false),
                    EventTopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_EventTopic_EventTopicId",
                        column: x => x.EventTopicId,
                        principalTable: "EventTopic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_EventType_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventTopicId",
                table: "Event",
                column: "EventTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventTypeId",
                table: "Event",
                column: "EventTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "EventTopic");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropSequence(
                name: "event_hilo");

            migrationBuilder.DropSequence(
                name: "event_topic_hilo");

            migrationBuilder.DropSequence(
                name: "event_type_hilo");
        }
    }
}
