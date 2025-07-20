using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackInovationMap.Migrations
{
    /// <inheritdoc />
    public partial class RemovePortafolioArcoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortafoliosArco");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PortafoliosArco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConvocatoriaId = table.Column<int>(type: "integer", nullable: true),
                    Anio = table.Column<int>(type: "integer", nullable: true),
                    Ciudad = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Cobertura = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Departamento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Enlace = table.Column<string>(type: "text", nullable: true),
                    Entidad = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Instrumento = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Latitud = table.Column<decimal>(type: "numeric", nullable: true),
                    Longitud = table.Column<decimal>(type: "numeric", nullable: true),
                    Objetivo = table.Column<string>(type: "text", nullable: true),
                    TipoApoyo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortafoliosArco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortafoliosArco_Convocatorias_ConvocatoriaId",
                        column: x => x.ConvocatoriaId,
                        principalTable: "Convocatorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortafoliosArco_Ciudad",
                table: "PortafoliosArco",
                column: "Ciudad");

            migrationBuilder.CreateIndex(
                name: "IX_PortafoliosArco_ConvocatoriaId",
                table: "PortafoliosArco",
                column: "ConvocatoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_PortafoliosArco_Departamento",
                table: "PortafoliosArco",
                column: "Departamento");
        }
    }
}
