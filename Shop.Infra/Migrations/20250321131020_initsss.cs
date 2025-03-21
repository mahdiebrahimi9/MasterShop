using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infra.Migrations
{
    /// <inheritdoc />
    public partial class initsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId1",
                schema: "User",
                table: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                schema: "User",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "User",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                schema: "User",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "User",
                table: "RefreshTokens");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "User",
                table: "RefreshTokens",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                schema: "User",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                schema: "User",
                table: "RefreshTokens",
                column: "UserId",
                principalSchema: "User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                schema: "User",
                table: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                schema: "User",
                table: "RefreshTokens");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "User",
                table: "RefreshTokens",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                schema: "User",
                table: "RefreshTokens",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                schema: "User",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "Id",
                schema: "User",
                table: "RefreshTokens",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                schema: "User",
                table: "RefreshTokens",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId1",
                schema: "User",
                table: "RefreshTokens",
                column: "UserId1",
                principalSchema: "User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
