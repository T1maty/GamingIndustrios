using System.ComponentModel.DataAnnotations;

namespace GamingIndustrios.Models
{
    public class Xbox:BaseObject
    {
        [Key]
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
