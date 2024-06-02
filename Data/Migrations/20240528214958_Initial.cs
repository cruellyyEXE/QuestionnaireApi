using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "re_surveys",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_re_surveys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "re_questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    survey_id = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_re_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_re_questions_re_surveys_survey_id",
                        column: x => x.survey_id,
                        principalTable: "re_surveys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "re_answers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    question_id = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_re_answers", x => x.id);
                    table.ForeignKey(
                        name: "FK_re_answers_re_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "re_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "re_interviews",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    question_id = table.Column<int>(type: "integer", nullable: false),
                    answer_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_re_interviews", x => x.id);
                    table.ForeignKey(
                        name: "FK_re_interviews_re_answers_answer_id",
                        column: x => x.answer_id,
                        principalTable: "re_answers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_re_interviews_re_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "re_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "re_result",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    answer_id = table.Column<int>(type: "integer", nullable: false),
                    times_selected = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_re_result", x => x.id);
                    table.ForeignKey(
                        name: "FK_re_result_re_answers_answer_id",
                        column: x => x.answer_id,
                        principalTable: "re_answers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_re_answers_question_id",
                table: "re_answers",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_re_interviews_answer_id",
                table: "re_interviews",
                column: "answer_id");

            migrationBuilder.CreateIndex(
                name: "IX_re_interviews_question_id",
                table: "re_interviews",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_re_questions_survey_id",
                table: "re_questions",
                column: "survey_id");

            migrationBuilder.CreateIndex(
                name: "IX_re_result_answer_id",
                table: "re_result",
                column: "answer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "re_interviews");

            migrationBuilder.DropTable(
                name: "re_result");

            migrationBuilder.DropTable(
                name: "re_answers");

            migrationBuilder.DropTable(
                name: "re_questions");

            migrationBuilder.DropTable(
                name: "re_surveys");
        }
    }
}
