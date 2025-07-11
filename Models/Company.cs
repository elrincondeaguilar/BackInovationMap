namespace BackInovationMap.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string LogoUrl { get; set; }
        public string Sector { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}