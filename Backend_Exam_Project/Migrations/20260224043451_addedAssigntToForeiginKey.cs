using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Exam_Project.Migrations
{
    /// <inheritdoc />
    public partial class addedAssigntToForeiginKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AssignedTo",
                table: "Tickets",
                column: "AssignedTo");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_AssignedTo",
                table: "Tickets",
                column: "AssignedTo",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_AssignedTo",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AssignedTo",
                table: "Tickets");
        }
    }
}
