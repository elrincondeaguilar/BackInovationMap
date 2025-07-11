using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackInovationMap.Migrations
{
    /// <inheritdoc />
    public partial class AddConvocatorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Convocatorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Categoria = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Entidad = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Presupuesto = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Estado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Requisitos = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convocatorias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Convocatorias_Categoria",
                table: "Convocatorias",
                column: "Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Convocatorias_Estado",
                table: "Convocatorias",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Convocatorias_FechaFin",
                table: "Convocatorias",
                column: "FechaFin");

            migrationBuilder.CreateIndex(
                name: "IX_Convocatorias_FechaInicio",
                table: "Convocatorias",
                column: "FechaInicio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Convocatorias");
        }
    }
}
