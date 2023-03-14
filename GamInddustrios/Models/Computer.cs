using System.ComponentModel.DataAnnotations;

namespace GamingIndustrios.Models
{
    public class Computer : BaseObject
    {
        [MaxLength(18)]
        public string? ComputerName { get; set; }
        [MaxLength(40)]
        public string? MotherBoard { get; set; }
        [MaxLength(20)]
        public string? Videocards { get; set; }
        [MaxLength(5)]
        public int Price { get; set; }
        [MaxLength(10)]
        public string? OS { get; set; }

    }
}
