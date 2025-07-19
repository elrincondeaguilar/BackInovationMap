using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackInovationMap.Migrations
{
    /// <inheritdoc />
    public partial class AddGeographicFieldsForMapIntegration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Promotores",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "Promotores",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitud",
                table: "Promotores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitud",
                table: "Promotores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "PortafoliosArco",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitud",
                table: "PortafoliosArco",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitud",
                table: "PortafoliosArco",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Articuladores",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "Articuladores",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitud",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitud",
                table: "Articuladores",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Promotores");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Promotores");

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Promotores");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Promotores");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "PortafoliosArco");

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "PortafoliosArco");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "PortafoliosArco");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Articuladores");
        }
    }
}
