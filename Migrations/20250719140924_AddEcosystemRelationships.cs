using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackInovationMap.Migrations
{
    /// <inheritdoc />
    public partial class AddEcosystemRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Promotores",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConvocatoriaId",
                table: "PortafoliosArco",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArticuladorCompanies",
                columns: table => new
                {
                    ArticuladorId = table.Column<int>(type: "integer", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notas = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TipoColaboracion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Activa = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticuladorCompanies", x => new { x.ArticuladorId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_ArticuladorCompanies_Articuladores_ArticuladorId",
                        column: x => x.ArticuladorId,
                        principalTable: "Articuladores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticuladorCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticuladorConvocatorias",
                columns: table => new
                {
                    ArticuladorId = table.Column<int>(type: "integer", nullable: false),
                    ConvocatoriaId = table.Column<int>(type: "integer", nullable: false),
                    Rol = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FechaAsignacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Responsabilidades = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticuladorConvocatorias", x => new { x.ArticuladorId, x.ConvocatoriaId });
                    table.ForeignKey(
                        name: "FK_ArticuladorConvocatorias_Articuladores_ArticuladorId",
                        column: x => x.ArticuladorId,
                        principalTable: "Articuladores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticuladorConvocatorias_Convocatorias_ConvocatoriaId",
                        column: x => x.ConvocatoriaId,
                        principalTable: "Convocatorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promotores_Ciudad",
                table: "Promotores",
                column: "Ciudad");

            migrationBuilder.CreateIndex(
                name: "IX_Promotores_CompanyId",
                table: "Promotores",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotores_Departamento",
                table: "Promotores",
                column: "Departamento");

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

            migrationBuilder.CreateIndex(
                name: "IX_Articuladores_Ciudad",
                table: "Articuladores",
                column: "Ciudad");

            migrationBuilder.CreateIndex(
                name: "IX_Articuladores_Departamento",
                table: "Articuladores",
                column: "Departamento");

            migrationBuilder.CreateIndex(
                name: "IX_Articuladores_Tipo",
                table: "Articuladores",
                column: "Tipo");

            migrationBuilder.CreateIndex(
                name: "IX_ArticuladorCompanies_Activa",
                table: "ArticuladorCompanies",
                column: "Activa");

            migrationBuilder.CreateIndex(
                name: "IX_ArticuladorCompanies_CompanyId",
                table: "ArticuladorCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticuladorCompanies_TipoColaboracion",
                table: "ArticuladorCompanies",
                column: "TipoColaboracion");

            migrationBuilder.CreateIndex(
                name: "IX_ArticuladorConvocatorias_Activo",
                table: "ArticuladorConvocatorias",
                column: "Activo");

            migrationBuilder.CreateIndex(
                name: "IX_ArticuladorConvocatorias_ConvocatoriaId",
                table: "ArticuladorConvocatorias",
                column: "ConvocatoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticuladorConvocatorias_Rol",
                table: "ArticuladorConvocatorias",
                column: "Rol");

            migrationBuilder.AddForeignKey(
                name: "FK_PortafoliosArco_Convocatorias_ConvocatoriaId",
                table: "PortafoliosArco",
                column: "ConvocatoriaId",
                principalTable: "Convocatorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotores_Companies_CompanyId",
                table: "Promotores",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortafoliosArco_Convocatorias_ConvocatoriaId",
                table: "PortafoliosArco");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotores_Companies_CompanyId",
                table: "Promotores");

            migrationBuilder.DropTable(
                name: "ArticuladorCompanies");

            migrationBuilder.DropTable(
                name: "ArticuladorConvocatorias");

            migrationBuilder.DropIndex(
                name: "IX_Promotores_Ciudad",
                table: "Promotores");

            migrationBuilder.DropIndex(
                name: "IX_Promotores_CompanyId",
                table: "Promotores");

            migrationBuilder.DropIndex(
                name: "IX_Promotores_Departamento",
                table: "Promotores");

            migrationBuilder.DropIndex(
                name: "IX_PortafoliosArco_Ciudad",
                table: "PortafoliosArco");

            migrationBuilder.DropIndex(
                name: "IX_PortafoliosArco_ConvocatoriaId",
                table: "PortafoliosArco");

            migrationBuilder.DropIndex(
                name: "IX_PortafoliosArco_Departamento",
                table: "PortafoliosArco");

            migrationBuilder.DropIndex(
                name: "IX_Articuladores_Ciudad",
                table: "Articuladores");

            migrationBuilder.DropIndex(
                name: "IX_Articuladores_Departamento",
                table: "Articuladores");

            migrationBuilder.DropIndex(
                name: "IX_Articuladores_Tipo",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Promotores");

            migrationBuilder.DropColumn(
                name: "ConvocatoriaId",
                table: "PortafoliosArco");
        }
    }
}
