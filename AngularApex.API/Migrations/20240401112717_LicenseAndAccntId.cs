using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularApex.API.Migrations
{
    public partial class LicenseAndAccntId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "UserAccounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "License",
                table: "UserAccounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "License",
                table: "UserAccounts");
        }
    }
}
