using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infra.Migrations
{
    /// <inheritdoc />
    public partial class initssssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "User",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                schema: "User",
                table: "Users");
        }
    }
}
