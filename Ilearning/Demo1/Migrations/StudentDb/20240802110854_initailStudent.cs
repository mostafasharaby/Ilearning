using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo1.Migrations.StudentDb
{
    /// <inheritdoc />
    public partial class initailStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Degree = table.Column<int>(type: "int", nullable: true),
                    Mindegree = table.Column<int>(type: "int", nullable: true),
                    Dep_id = table.Column<int>(type: "int", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Departes_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Traniees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Degree = table.Column<int>(type: "int", nullable: true),
                    Dep_id = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    DepartementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traniees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Traniees_Departes_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Instractors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: true),
                    Dep_id = table.Column<int>(type: "int", nullable: false),
                    crs_id = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    DepartementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instractors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instractors_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Instractors_Departes_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CrsResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<int>(type: "int", nullable: true),
                    Traniee_id = table.Column<int>(type: "int", nullable: true),
                    crs_id = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    TranieeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrsResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrsResults_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CrsResults_Traniees_TranieeId",
                        column: x => x.TranieeId,
                        principalTable: "Traniees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartementId",
                table: "Courses",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_CrsResults_CourseId",
                table: "CrsResults",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CrsResults_TranieeId",
                table: "CrsResults",
                column: "TranieeId");

            migrationBuilder.CreateIndex(
                name: "IX_Instractors_CourseId",
                table: "Instractors",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Instractors_DepartementId",
                table: "Instractors",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Traniees_DepartementId",
                table: "Traniees",
                column: "DepartementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrsResults");

            migrationBuilder.DropTable(
                name: "Instractors");

            migrationBuilder.DropTable(
                name: "Traniees");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Departes");
        }
    }
}
