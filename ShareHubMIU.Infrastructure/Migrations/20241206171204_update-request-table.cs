using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareHubMIU.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updaterequesttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Requests_ItemId",
                table: "Requests",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Items_ItemId",
                table: "Requests",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Items_ItemId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ItemId",
                table: "Requests");
        }
    }
}
