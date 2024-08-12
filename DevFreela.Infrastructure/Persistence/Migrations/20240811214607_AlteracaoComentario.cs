using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevFreela.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoComentario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComments_Projects_IdProject",
                table: "ProjectComments");

            migrationBuilder.DropIndex(
                name: "IX_ProjectComments_IdProject",
                table: "ProjectComments");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectComments_IdUser",
                table: "ProjectComments",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComments_Projects_IdUser",
                table: "ProjectComments",
                column: "IdUser",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComments_Projects_IdUser",
                table: "ProjectComments");

            migrationBuilder.DropIndex(
                name: "IX_ProjectComments_IdUser",
                table: "ProjectComments");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectComments_IdProject",
                table: "ProjectComments",
                column: "IdProject");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComments_Projects_IdProject",
                table: "ProjectComments",
                column: "IdProject",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
