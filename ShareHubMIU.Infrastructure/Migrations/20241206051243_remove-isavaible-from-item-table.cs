using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareHubMIU.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeisavaiblefromitemtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Items");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Items",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Items");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
