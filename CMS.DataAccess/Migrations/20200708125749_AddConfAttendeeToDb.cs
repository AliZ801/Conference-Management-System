using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.DataAccess.Migrations
{
    public partial class AddConfAttendeeToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConferenceAttendees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConferenceId = table.Column<int>(nullable: false),
                    AttendeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceAttendees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConferenceAttendees_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConferenceAttendees_Conference_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceAttendees_AttendeeId",
                table: "ConferenceAttendees",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceAttendees_ConferenceId",
                table: "ConferenceAttendees",
                column: "ConferenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConferenceAttendees");
        }
    }
}
