using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularApex.API.Migrations
{
    public partial class AccountAssignedTO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountsAssigned",
                table: "UserAccounts");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CreatedById",
                table: "Accounts",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_UserAccounts_CreatedById",
                table: "Accounts",
                column: "CreatedById",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_UserAccounts_CreatedById",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CreatedById",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "AccountsAssigned",
                table: "UserAccounts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
