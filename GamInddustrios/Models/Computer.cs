namespace GamingIndustrios.Models
{
    public class Computer : BaseObject
    {
        public string ComputerName { get; set; }
        public string MotherBoard { get; set; }
        public string Videocards { get; set; }
        public int Price { get; set; }
        public string OS { get; set; }
    }
}
