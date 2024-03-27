using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularApex.API.Migrations
{
    public partial class UserRoleAssigments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "UserRoleAssigments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleAssigments_UserRoleId",
                table: "UserRoleAssigments",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleAssigments_UserRoles_UserRoleId",
                table: "UserRoleAssigments",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleAssigments_UserRoles_UserRoleId",
                table: "UserRoleAssigments");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleAssigments_UserRoleId",
                table: "UserRoleAssigments");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "UserRoleAssigments");
        }
    }
}
