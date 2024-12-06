using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareHubMIU.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changecolumncommonitemtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubCategory",
                table: "Items",
                newName: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Items",
                newName: "SubCategory");
        }
    }
}
