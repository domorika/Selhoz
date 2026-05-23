using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Selhoz.Migrations
{
    /// <inheritdoc />
    public partial class RenameCultureToPlant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantingJournal_Plants_PlantId",
                table: "PlantingJournal");

            migrationBuilder.DropColumn(
                name: "PlantId",
                table: "PlantingJournal");

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "PlantingJournal",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingJournal_Plants_PlantId",
                table: "PlantingJournal",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantingJournal_Plants_PlantId",
                table: "PlantingJournal");

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "PlantingJournal",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "PlantId",
                table: "PlantingJournal",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingJournal_Plants_PlantId",
                table: "PlantingJournal",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id");
        }
    }
}
