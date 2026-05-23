using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Selhoz.Migrations
{
    /// <inheritdoc />
    public partial class AddAllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plantingjournal_fields_field_id",
                table: "plantingjournal");

            migrationBuilder.DropForeignKey(
                name: "FK_plantingjournal_plants_plant_id",
                table: "plantingjournal");

            migrationBuilder.DropForeignKey(
                name: "FK_plantingjournal_workers_worker_id",
                table: "plantingjournal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workers",
                table: "workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_plants",
                table: "plants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_plantingjournal",
                table: "plantingjournal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fields",
                table: "fields");

            migrationBuilder.DropColumn(
                name: "climate_zone",
                table: "plants");

            migrationBuilder.DropColumn(
                name: "plant_name",
                table: "plants");

            migrationBuilder.DropColumn(
                name: "plant_type",
                table: "plants");

            migrationBuilder.DropColumn(
                name: "seed_amount",
                table: "plantingjournal");

            migrationBuilder.DropColumn(
                name: "field_name",
                table: "fields");

            migrationBuilder.DropColumn(
                name: "irrigation",
                table: "fields");

            migrationBuilder.DropColumn(
                name: "last_crop",
                table: "fields");

            migrationBuilder.RenameTable(
                name: "workers",
                newName: "Workers");

            migrationBuilder.RenameTable(
                name: "plants",
                newName: "Plants");

            migrationBuilder.RenameTable(
                name: "plantingjournal",
                newName: "PlantingJournal");

            migrationBuilder.RenameTable(
                name: "fields",
                newName: "Fields");

            migrationBuilder.RenameColumn(
                name: "water_requirements",
                table: "Plants",
                newName: "WaterRequirements");

            migrationBuilder.RenameColumn(
                name: "growth_period",
                table: "Plants",
                newName: "GrowthPeriodDays");

            migrationBuilder.RenameColumn(
                name: "plant_id",
                table: "Plants",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "PlantingJournal",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "worker_id",
                table: "PlantingJournal",
                newName: "WorkerId");

            migrationBuilder.RenameColumn(
                name: "planting_date",
                table: "PlantingJournal",
                newName: "PlantingDate");

            migrationBuilder.RenameColumn(
                name: "plant_id",
                table: "PlantingJournal",
                newName: "PlantId");

            migrationBuilder.RenameColumn(
                name: "harvest_date",
                table: "PlantingJournal",
                newName: "HarvestDate");

            migrationBuilder.RenameColumn(
                name: "field_id",
                table: "PlantingJournal",
                newName: "FieldId");

            migrationBuilder.RenameColumn(
                name: "record_id",
                table: "PlantingJournal",
                newName: "PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_plantingjournal_worker_id",
                table: "PlantingJournal",
                newName: "IX_PlantingJournal_WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_plantingjournal_plant_id",
                table: "PlantingJournal",
                newName: "IX_PlantingJournal_PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_plantingjournal_field_id",
                table: "PlantingJournal",
                newName: "IX_PlantingJournal_FieldId");

            migrationBuilder.RenameColumn(
                name: "area",
                table: "Fields",
                newName: "Area");

            migrationBuilder.RenameColumn(
                name: "soil_type",
                table: "Fields",
                newName: "SoilType");

            migrationBuilder.RenameColumn(
                name: "field_id",
                table: "Fields",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "WaterRequirements",
                table: "Plants",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "ClimateRequirements",
                table: "Plants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Plants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Plants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PlantingJournal",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "PlantingJournal",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "PlantingJournal",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PlantingJournal",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "PlantingJournal",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SoilType",
                table: "Fields",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "FieldNumber",
                table: "Fields",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IrrigationType",
                table: "Fields",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Fields",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workers",
                table: "Workers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plants",
                table: "Plants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantingJournal",
                table: "PlantingJournal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fields",
                table: "Fields",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingJournal_Fields_FieldId",
                table: "PlantingJournal",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingJournal_Plants_PlantId",
                table: "PlantingJournal",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingJournal_Workers_WorkerId",
                table: "PlantingJournal",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantingJournal_Fields_FieldId",
                table: "PlantingJournal");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingJournal_Plants_PlantId",
                table: "PlantingJournal");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingJournal_Workers_WorkerId",
                table: "PlantingJournal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workers",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plants",
                table: "Plants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantingJournal",
                table: "PlantingJournal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fields",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "ClimateRequirements",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlantingJournal");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "PlantingJournal");

            migrationBuilder.DropColumn(
                name: "FieldNumber",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "IrrigationType",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Fields");

            migrationBuilder.RenameTable(
                name: "Workers",
                newName: "workers");

            migrationBuilder.RenameTable(
                name: "Plants",
                newName: "plants");

            migrationBuilder.RenameTable(
                name: "PlantingJournal",
                newName: "plantingjournal");

            migrationBuilder.RenameTable(
                name: "Fields",
                newName: "fields");

            migrationBuilder.RenameColumn(
                name: "WaterRequirements",
                table: "plants",
                newName: "water_requirements");

            migrationBuilder.RenameColumn(
                name: "GrowthPeriodDays",
                table: "plants",
                newName: "growth_period");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "plants",
                newName: "plant_id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "plantingjournal",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "plantingjournal",
                newName: "worker_id");

            migrationBuilder.RenameColumn(
                name: "PlantingDate",
                table: "plantingjournal",
                newName: "planting_date");

            migrationBuilder.RenameColumn(
                name: "PlantId",
                table: "plantingjournal",
                newName: "plant_id");

            migrationBuilder.RenameColumn(
                name: "HarvestDate",
                table: "plantingjournal",
                newName: "harvest_date");

            migrationBuilder.RenameColumn(
                name: "FieldId",
                table: "plantingjournal",
                newName: "field_id");

            migrationBuilder.RenameColumn(
                name: "PlantId",
                table: "plantingjournal",
                newName: "record_id");

            migrationBuilder.RenameIndex(
                name: "IX_PlantingJournal_WorkerId",
                table: "plantingjournal",
                newName: "IX_plantingjournal_worker_id");

            migrationBuilder.RenameIndex(
                name: "IX_PlantingJournal_PlantId",
                table: "plantingjournal",
                newName: "IX_plantingjournal_plant_id");

            migrationBuilder.RenameIndex(
                name: "IX_PlantingJournal_FieldId",
                table: "plantingjournal",
                newName: "IX_plantingjournal_field_id");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "fields",
                newName: "area");

            migrationBuilder.RenameColumn(
                name: "SoilType",
                table: "fields",
                newName: "soil_type");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "fields",
                newName: "field_id");

            migrationBuilder.AlterColumn<string>(
                name: "water_requirements",
                table: "plants",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "climate_zone",
                table: "plants",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "plant_name",
                table: "plants",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "plant_type",
                table: "plants",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "plantingjournal",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "plant_id",
                table: "plantingjournal",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "record_id",
                table: "plantingjournal",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<decimal>(
                name: "seed_amount",
                table: "plantingjournal",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "soil_type",
                table: "fields",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "field_name",
                table: "fields",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "irrigation",
                table: "fields",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "last_crop",
                table: "fields",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workers",
                table: "workers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_plants",
                table: "plants",
                column: "plant_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_plantingjournal",
                table: "plantingjournal",
                column: "record_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fields",
                table: "fields",
                column: "field_id");

            migrationBuilder.AddForeignKey(
                name: "FK_plantingjournal_fields_field_id",
                table: "plantingjournal",
                column: "field_id",
                principalTable: "fields",
                principalColumn: "field_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_plantingjournal_plants_plant_id",
                table: "plantingjournal",
                column: "plant_id",
                principalTable: "plants",
                principalColumn: "plant_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_plantingjournal_workers_worker_id",
                table: "plantingjournal",
                column: "worker_id",
                principalTable: "workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
