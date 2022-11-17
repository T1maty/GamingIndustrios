namespace GamingIndustrios.Models
{
    public class Playstation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public void ApplyTo(Playstation playstation)
        {
            throw new NotImplementedException();
        }
    }
}
