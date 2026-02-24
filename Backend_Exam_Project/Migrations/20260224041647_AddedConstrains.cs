using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Exam_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddedConstrains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketComments_Users_CommentedByID",
                table: "TicketComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_CreatedBy",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatusLogs_Users_ChangedByID",
                table: "TicketStatusLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(555)",
                maxLength: 555,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tickets",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Tickets",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Open",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Tickets",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Medium",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddCheckConstraint(
                name: "CK_TicketStatusLogs_NewStatus",
                table: "TicketStatusLogs",
                sql: "NewStatus IN ('Open','In Progress','Resolved', 'Closed')");

            migrationBuilder.AddCheckConstraint(
                name: "CK_TicketStatusLogs_OldStatus",
                table: "TicketStatusLogs",
                sql: "OldStatus IN ('Open','In Progress','Resolved', 'Closed')");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Tickets_Priority",
                table: "Tickets",
                sql: "Priority IN ('Low','Medium','High')");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Tickets_Status",
                table: "Tickets",
                sql: "Status IN ('Open','In Progress','Resolved', 'Closed')");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Roles_RoleName",
                table: "Roles",
                sql: "RoleName IN ('Manager','Support','User')");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComments_Users_CommentedByID",
                table: "TicketComments",
                column: "CommentedByID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_CreatedBy",
                table: "Tickets",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatusLogs_Users_ChangedByID",
                table: "TicketStatusLogs",
                column: "ChangedByID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketComments_Users_CommentedByID",
                table: "TicketComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_CreatedBy",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatusLogs_Users_ChangedByID",
                table: "TicketStatusLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users");

            migrationBuilder.DropCheckConstraint(
                name: "CK_TicketStatusLogs_NewStatus",
                table: "TicketStatusLogs");

            migrationBuilder.DropCheckConstraint(
                name: "CK_TicketStatusLogs_OldStatus",
                table: "TicketStatusLogs");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Tickets_Priority",
                table: "Tickets");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Tickets_Status",
                table: "Tickets");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Roles_RoleName",
                table: "Roles");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(555)",
                oldMaxLength: 555);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Open");

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Medium");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComments_Users_CommentedByID",
                table: "TicketComments",
                column: "CommentedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_CreatedBy",
                table: "Tickets",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatusLogs_Users_ChangedByID",
                table: "TicketStatusLogs",
                column: "ChangedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
