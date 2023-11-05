using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Migrations
{
    /// <inheritdoc />
    public partial class TimeTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupNum = table.Column<int>(type: "int", nullable: false),
                    CourseId1 = table.Column<int>(type: "int", nullable: false),
                    CourseId2 = table.Column<int>(type: "int", nullable: false),
                    CourseId3 = table.Column<int>(type: "int", nullable: false),
                    CourseId4 = table.Column<int>(type: "int", nullable: false),
                    CourseId5 = table.Column<int>(type: "int", nullable: false),
                    CourseId6 = table.Column<int>(type: "int", nullable: false),
                    CourseId7 = table.Column<int>(type: "int", nullable: false),
                    CourseId8 = table.Column<int>(type: "int", nullable: false),
                    CourseId9 = table.Column<int>(type: "int", nullable: false),
                    CourseId10 = table.Column<int>(type: "int", nullable: false),
                    CourseId11 = table.Column<int>(type: "int", nullable: false),
                    CourseId12 = table.Column<int>(type: "int", nullable: false),
                    CourseId13 = table.Column<int>(type: "int", nullable: false),
                    CourseId14 = table.Column<int>(type: "int", nullable: false),
                    CourseId15 = table.Column<int>(type: "int", nullable: false),
                    CourseId16 = table.Column<int>(type: "int", nullable: false),
                    CourseId17 = table.Column<int>(type: "int", nullable: false),
                    CourseId18 = table.Column<int>(type: "int", nullable: false),
                    CourseId19 = table.Column<int>(type: "int", nullable: false),
                    CourseId20 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTables", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeTables");
        }
    }
}
