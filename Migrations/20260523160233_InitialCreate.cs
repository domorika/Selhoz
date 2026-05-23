using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Selhoz.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fields",
                columns: table => new
                {
                    field_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    field_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    area = table.Column<decimal>(type: "numeric", nullable: false),
                    soil_type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    irrigation = table.Column<bool>(type: "boolean", nullable: false),
                    last_crop = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fields", x => x.field_id);
                });

            migrationBuilder.CreateTable(
                name: "plants",
                columns: table => new
                {
                    plant_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    plant_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    plant_type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    growth_period = table.Column<int>(type: "integer", nullable: false),
                    water_requirements = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    climate_zone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plants", x => x.plant_id);
                });

            migrationBuilder.CreateTable(
                name: "workers",
                columns: table => new
                {
                    worker_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    position = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    contact_phone = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    qualification = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers", x => x.worker_id);
                });

            migrationBuilder.CreateTable(
                name: "plantingjournal",
                columns: table => new
                {
                    record_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    field_id = table.Column<int>(type: "integer", nullable: false),
                    plant_id = table.Column<int>(type: "integer", nullable: false),
                    worker_id = table.Column<int>(type: "integer", nullable: false),
                    planting_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    harvest_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    seed_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plantingjournal", x => x.record_id);
                    table.ForeignKey(
                        name: "FK_plantingjournal_fields_field_id",
                        column: x => x.field_id,
                        principalTable: "fields",
                        principalColumn: "field_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_plantingjournal_plants_plant_id",
                        column: x => x.plant_id,
                        principalTable: "plants",
                        principalColumn: "plant_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_plantingjournal_workers_worker_id",
                        column: x => x.worker_id,
                        principalTable: "workers",
                        principalColumn: "worker_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_plantingjournal_field_id",
                table: "plantingjournal",
                column: "field_id");

            migrationBuilder.CreateIndex(
                name: "IX_plantingjournal_plant_id",
                table: "plantingjournal",
                column: "plant_id");

            migrationBuilder.CreateIndex(
                name: "IX_plantingjournal_worker_id",
                table: "plantingjournal",
                column: "worker_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plantingjournal");

            migrationBuilder.DropTable(
                name: "fields");

            migrationBuilder.DropTable(
                name: "plants");

            migrationBuilder.DropTable(
                name: "workers");
        }
    }
}
