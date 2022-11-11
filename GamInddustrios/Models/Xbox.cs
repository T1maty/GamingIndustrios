namespace GamingIndustrios.Models
{
    public class Xbox
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
