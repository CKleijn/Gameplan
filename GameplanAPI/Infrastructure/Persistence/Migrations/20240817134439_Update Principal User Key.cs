using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameplanAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePrincipalUserKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Users_UserId",
                table: "Seasons");

            migrationBuilder.AlterColumn<string>(
                name: "UID",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Seasons",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Matches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_UID",
                table: "Users",
                column: "UID");

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Users_UserId",
                table: "Seasons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Users_UserId",
                table: "Seasons");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_UID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Matches");

            migrationBuilder.AlterColumn<string>(
                name: "UID",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Seasons",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Users_UserId",
                table: "Seasons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
