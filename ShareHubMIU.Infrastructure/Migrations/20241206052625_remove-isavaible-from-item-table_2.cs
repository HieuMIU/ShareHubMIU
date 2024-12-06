using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareHubMIU.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeisavaiblefromitemtable_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Items",
                type: "bit",
                nullable: true);
        }
    }
}
