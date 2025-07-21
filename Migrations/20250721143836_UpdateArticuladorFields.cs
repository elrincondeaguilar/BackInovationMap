using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackInovationMap.Migrations
{
    /// <inheritdoc />
    public partial class UpdateArticuladorFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccesoBeneficiarios",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActividadesFormulacionImplementacion",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AdaptaDiferenciasTerritorios",
                table: "Articuladores",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Anio",
                table: "Articuladores",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AntiguedadOferta",
                table: "Articuladores",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ApoyoFinanciero",
                table: "Articuladores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AsistenciaTecnica",
                table: "Articuladores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BarrerasFuncionamientoInstrumento",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BonosBouchers",
                table: "Articuladores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Cobertura",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Articuladores",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CompraPublica",
                table: "Articuladores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ConsideraCoordinacionOtrasEntidades",
                table: "Articuladores",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CriteriosFocalizacionBeneficiarios",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartamentosMunicipios",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DescritoDocumentoInterno",
                table: "Articuladores",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DisenadoPorLeyOJuez",
                table: "Articuladores",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DisenadoPorPolitica",
                table: "Articuladores",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DisponibilidadRecursos",
                table: "Articuladores",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Entidad",
                table: "Articuladores",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Eventos",
                table: "Articuladores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExistenAlternativasInstrumento",
                table: "Articuladores",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaApertura",
                table: "Articuladores",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCierre",
                table: "Articuladores",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FormacionTalentoHumano",
                table: "Articuladores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "GestionAprendizajesInstrumento",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GestionInformacionInstrumento",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GestionOrganizativa",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IncentivosTributarios",
                table: "Articuladores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "InstrumentosOfertados",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InstrumentosRegulatorios",
                table: "Articuladores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "InsumosFormulacionImplementacion",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonitoreoEvaluacionInstrumento",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoCalidad",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoClusterEncadenamientos",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoComercializacion",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoComercioElectronico",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoCrecimientoSostenible",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoEmprendimiento",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoFinanciacion",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoFormacionCapitalHumano",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoFormalizacion",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoInclusionFinanciera",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoInnovacion",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoInvestigacion",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoTransferenciaConocimientoTecnologia",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivosFormulacionInstrumento",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrigenInstrumento",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pagina",
                table: "Articuladores",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalApoyoFormulacionImplementacion",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PoblacionObjetivo",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeCalidad",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeClusterEncadenamientos",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeComercializacion",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeComercioElectronico",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeCrecimientoSostenible",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeEmprendimiento",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeFinanciacion",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeFormacionCapitalHumano",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeFormalizacion",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeInclusionFinanciera",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeInnovacion",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeInvestigacion",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeTransferenciaConocimientoTecnologia",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PremiosReconocimientos",
                table: "Articuladores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProductosGeneradosInstrumento",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RecursosCooperacion",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RecursosEsfuerzoFiscal",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RecursosOtros",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RecursosPGN",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RecursosParafiscales",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RecursosPrivado",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RecursosSGR",
                table: "Articuladores",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RedesColaboracion",
                table: "Articuladores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RelacionConOtrosInstrumentos",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultadosImpactosEsperados",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "Articuladores",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeleccionBeneficiarios",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SistemasInformacion",
                table: "Articuladores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SolucionaFallaMercadoGobiernoArticulacion",
                table: "Articuladores",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TieneMarcoLogico",
                table: "Articuladores",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TrazabilidadBeneficiarios",
                table: "Articuladores",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuariosAcademia",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuariosEmprendedores",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuariosEntidadesGobierno",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuariosGrandesEmpresas",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuariosMiPymes",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuariosOrganizacionesSoporte",
                table: "Articuladores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuariosPersonasNaturales",
                table: "Articuladores",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccesoBeneficiarios",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ActividadesFormulacionImplementacion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "AdaptaDiferenciasTerritorios",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "Anio",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "AntiguedadOferta",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ApoyoFinanciero",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "AsistenciaTecnica",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "BarrerasFuncionamientoInstrumento",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "BonosBouchers",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "Cobertura",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "CompraPublica",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ConsideraCoordinacionOtrasEntidades",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "CriteriosFocalizacionBeneficiarios",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "DepartamentosMunicipios",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "DescritoDocumentoInterno",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "DisenadoPorLeyOJuez",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "DisenadoPorPolitica",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "DisponibilidadRecursos",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "Entidad",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "Eventos",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ExistenAlternativasInstrumento",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "FechaApertura",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "FechaCierre",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "FormacionTalentoHumano",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "GestionAprendizajesInstrumento",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "GestionInformacionInstrumento",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "GestionOrganizativa",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "IncentivosTributarios",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "InstrumentosOfertados",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "InstrumentosRegulatorios",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "InsumosFormulacionImplementacion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "MonitoreoEvaluacionInstrumento",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ObjetivoCalidad",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ObjetivoClusterEncadenamientos",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ObjetivoComercializacion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ObjetivoComercioElectronico",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ObjetivoCrecimientoSostenible",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ObjetivoEmprendimiento",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ObjetivoFinanciacion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ObjetivoFormacionCapitalHumano",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ObjetivoFormalizacion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ObjetivoInclusionFinanciera",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ObjetivoInnovacion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ObjetivoInvestigacion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ObjetivoTransferenciaConocimientoTecnologia",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ObjetivosFormulacionInstrumento",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "OrigenInstrumento",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "Pagina",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "PersonalApoyoFormulacionImplementacion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "PoblacionObjetivo",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "PorcentajeCalidad",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "PorcentajeClusterEncadenamientos",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "PorcentajeComercializacion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "PorcentajeComercioElectronico",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "PorcentajeCrecimientoSostenible",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "PorcentajeEmprendimiento",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "PorcentajeFinanciacion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "PorcentajeFormacionCapitalHumano",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "PorcentajeFormalizacion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "PorcentajeInclusionFinanciera",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "PorcentajeInnovacion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "PorcentajeInvestigacion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "PorcentajeTransferenciaConocimientoTecnologia",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "PremiosReconocimientos",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ProductosGeneradosInstrumento",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "RecursosCooperacion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "RecursosEsfuerzoFiscal",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "RecursosOtros",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "RecursosPGN",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "RecursosParafiscales",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "RecursosPrivado",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "RecursosSGR",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "RedesColaboracion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "RelacionConOtrosInstrumentos",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "ResultadosImpactosEsperados",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "Sector",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "SeleccionBeneficiarios",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "SistemasInformacion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "SolucionaFallaMercadoGobiernoArticulacion",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "TieneMarcoLogico",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "TrazabilidadBeneficiarios",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "UsuariosAcademia",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "UsuariosEmprendedores",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "UsuariosEntidadesGobierno",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "UsuariosGrandesEmpresas",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "UsuariosMiPymes",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "UsuariosOrganizacionesSoporte",
                table: "Articuladores");

            migrationBuilder.DropColumn(
                name: "UsuariosPersonasNaturales",
                table: "Articuladores");
        }
    }
}
