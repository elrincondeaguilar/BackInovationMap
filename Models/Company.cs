namespace BackInovationMap.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        // Nuevos campos del modelo actores_innovacion
        public string? TipoActor { get; set; } // articulador, habilitador, comunidad, etc.
        public string? Ciudad { get; set; }
        public string? Direccion { get; set; }
        public string? Contacto { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}