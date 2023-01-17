namespace GamingIndustrios.Models
{
    public class Driver
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int DriverNumber { get; set; }
        public DateTime DateUpdated { get; set; }
        public int Status { get; set; }
        public string? WorldChampionships { get; set; }
        public DateTime DateAdded { get; internal set; }
    }
}
