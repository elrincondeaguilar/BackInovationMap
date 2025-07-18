using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackInovationMap.Migrations
{
    /// <inheritdoc />
    public partial class AddExtendedModelsAndNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Clasificacion",
                table: "Convocatorias",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Enlace",
                table: "Convocatorias",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaApertura",
                table: "Convocatorias",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCierre",
                table: "Convocatorias",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LineaOportunidad",
                table: "Convocatorias",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PalabrasClave",
                table: "Convocatorias",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Companies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contacto",
                table: "Companies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Companies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitud",
                table: "Companies",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitud",
                table: "Companies",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoActor",
                table: "Companies",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Articuladores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Tipo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Region = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Contacto = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articuladores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortafoliosArco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Anio = table.Column<int>(type: "integer", nullable: true),
                    Entidad = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Instrumento = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TipoApoyo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Objetivo = table.Column<string>(type: "text", nullable: true),
                    Cobertura = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Departamento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Enlace = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortafoliosArco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Medio = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Enlace = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articuladores");

            migrationBuilder.DropTable(
                name: "PortafoliosArco");

            migrationBuilder.DropTable(
                name: "Promotores");

            migrationBuilder.DropColumn(
                name: "Clasificacion",
                table: "Convocatorias");

            migrationBuilder.DropColumn(
                name: "Enlace",
                table: "Convocatorias");

            migrationBuilder.DropColumn(
                name: "FechaApertura",
                table: "Convocatorias");

            migrationBuilder.DropColumn(
                name: "FechaCierre",
                table: "Convocatorias");

            migrationBuilder.DropColumn(
                name: "LineaOportunidad",
                table: "Convocatorias");

            migrationBuilder.DropColumn(
                name: "PalabrasClave",
                table: "Convocatorias");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Contacto",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TipoActor",
                table: "Companies");
        }
    }
}
