using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.Data.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EntrncesLeft",
                table: "Subscriptions",
                newName: "EntrancesLeft");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEntrance",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastEntrance",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "EntrancesLeft",
                table: "Subscriptions",
                newName: "EntrncesLeft");
        }
    }
}
