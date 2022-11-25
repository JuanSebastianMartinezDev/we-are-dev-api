using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeAreDevApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Client_SectorId",
                table: "Client",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Sector_SectorId",
                table: "Client",
                column: "SectorId",
                principalTable: "Sector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Sector_SectorId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_SectorId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Client");
        }
    }
}
