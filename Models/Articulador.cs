using System.ComponentModel.DataAnnotations;

namespace BackInovationMap.Models
{
    public class Articulador
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Nombre { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string? Tipo { get; set; }
        
        [StringLength(100)]
        public string? Region { get; set; }
        
        public string? Contacto { get; set; }
        
        // Campos geográficos para visualización en mapa
        [StringLength(100)]
        public string? Ciudad { get; set; }
        
        [StringLength(100)]
        public string? Departamento { get; set; }
        
        public decimal? Latitud { get; set; }
        
        public decimal? Longitud { get; set; }
        
        // Relaciones many-to-many
        public ICollection<ArticuladorCompany>? ArticuladorCompanies { get; set; }
        public ICollection<ArticuladorConvocatoria>? ArticuladorConvocatorias { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        // --- CAMPOS EXTENDIDOS ---
        public int? Anio { get; set; }
        [StringLength(100)] public string? Codigo { get; set; }
        [StringLength(100)] public string? Sector { get; set; }
        [StringLength(200)] public string? Entidad { get; set; }
        public string? InstrumentosOfertados { get; set; }
        public int? AntiguedadOferta { get; set; }
        [StringLength(200)] public string? Pagina { get; set; }
        public string? Descripcion { get; set; }
        public string? UsuariosEmprendedores { get; set; }
        public string? UsuariosMiPymes { get; set; }
        public string? UsuariosGrandesEmpresas { get; set; }
        public string? UsuariosAcademia { get; set; }
        public string? UsuariosEntidadesGobierno { get; set; }
        public string? UsuariosOrganizacionesSoporte { get; set; }
        public string? UsuariosPersonasNaturales { get; set; }
        // Tipos de apoyo
        public bool ApoyoFinanciero { get; set; }
        public bool AsistenciaTecnica { get; set; }
        public bool FormacionTalentoHumano { get; set; }
        public bool IncentivosTributarios { get; set; }
        public bool Eventos { get; set; }
        public bool CompraPublica { get; set; }
        public bool RedesColaboracion { get; set; }
        public bool BonosBouchers { get; set; }
        public bool SistemasInformacion { get; set; }
        public bool PremiosReconocimientos { get; set; }
        public bool InstrumentosRegulatorios { get; set; }
        // Fechas
        public DateTime? FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }
        public string? Cobertura { get; set; }
        public string? DepartamentosMunicipios { get; set; }
        // Objetivos y % dedicación
        public string? ObjetivoFormacionCapitalHumano { get; set; }
        public decimal? PorcentajeFormacionCapitalHumano { get; set; }
        public string? ObjetivoComercioElectronico { get; set; }
        public decimal? PorcentajeComercioElectronico { get; set; }
        public string? ObjetivoInnovacion { get; set; }
        public decimal? PorcentajeInnovacion { get; set; }
        public string? ObjetivoEmprendimiento { get; set; }
        public decimal? PorcentajeEmprendimiento { get; set; }
        public string? ObjetivoTransferenciaConocimientoTecnologia { get; set; }
        public decimal? PorcentajeTransferenciaConocimientoTecnologia { get; set; }
        public string? ObjetivoInvestigacion { get; set; }
        public decimal? PorcentajeInvestigacion { get; set; }
        public string? ObjetivoCalidad { get; set; }
        public decimal? PorcentajeCalidad { get; set; }
        public string? ObjetivoClusterEncadenamientos { get; set; }
        public decimal? PorcentajeClusterEncadenamientos { get; set; }
        public string? ObjetivoFinanciacion { get; set; }
        public decimal? PorcentajeFinanciacion { get; set; }
        public string? ObjetivoComercializacion { get; set; }
        public decimal? PorcentajeComercializacion { get; set; }
        public string? ObjetivoFormalizacion { get; set; }
        public decimal? PorcentajeFormalizacion { get; set; }
        public string? ObjetivoCrecimientoSostenible { get; set; }
        public decimal? PorcentajeCrecimientoSostenible { get; set; }
        public string? ObjetivoInclusionFinanciera { get; set; }
        public decimal? PorcentajeInclusionFinanciera { get; set; }
        // Recursos
        public decimal? RecursosPGN { get; set; }
        public decimal? RecursosCooperacion { get; set; }
        public decimal? RecursosSGR { get; set; }
        public decimal? RecursosEsfuerzoFiscal { get; set; }
        public decimal? RecursosParafiscales { get; set; }
        public decimal? RecursosOtros { get; set; }
        public decimal? RecursosPrivado { get; set; }
        // Origen y marco lógico
        public bool? DisenadoPorLeyOJuez { get; set; }
        public bool? DisenadoPorPolitica { get; set; }
        public bool? DescritoDocumentoInterno { get; set; }
        public string? OrigenInstrumento { get; set; }
        public bool? SolucionaFallaMercadoGobiernoArticulacion { get; set; }
        public bool? ExistenAlternativasInstrumento { get; set; }
        public string? ObjetivosFormulacionInstrumento { get; set; }
        public bool? TieneMarcoLogico { get; set; }
        public string? InsumosFormulacionImplementacion { get; set; }
        public string? ActividadesFormulacionImplementacion { get; set; }
        public string? ProductosGeneradosInstrumento { get; set; }
        public string? ResultadosImpactosEsperados { get; set; }
        public string? PoblacionObjetivo { get; set; }
        public string? CriteriosFocalizacionBeneficiarios { get; set; }
        public bool? AdaptaDiferenciasTerritorios { get; set; }
        public string? SeleccionBeneficiarios { get; set; }
        public string? AccesoBeneficiarios { get; set; }
        public bool? TrazabilidadBeneficiarios { get; set; }
        public bool? DisponibilidadRecursos { get; set; }
        public string? GestionOrganizativa { get; set; }
        public string? PersonalApoyoFormulacionImplementacion { get; set; }
        public string? GestionInformacionInstrumento { get; set; }
        public string? MonitoreoEvaluacionInstrumento { get; set; }
        public string? GestionAprendizajesInstrumento { get; set; }
        public string? RelacionConOtrosInstrumentos { get; set; }
        public bool? ConsideraCoordinacionOtrasEntidades { get; set; }
        public string? BarrerasFuncionamientoInstrumento { get; set; }
    }
}
