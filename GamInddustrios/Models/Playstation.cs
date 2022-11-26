namespace GamingIndustrios.Models
{
    public class Playstation : BaseObject
    {

        public string Name { get; set; }
        public int Price { get; set; }

        public void ApplyTo(Playstation playstation)
        {
            throw new NotImplementedException();
        }
    }
}
