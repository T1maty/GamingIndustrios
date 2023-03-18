using System.ComponentModel.DataAnnotations;

namespace GamingIndustrios.Models
{
    public class Xbox: BaseObject
    {

        public string Username { get; set; }
        public string NameXbox { get; set; }
        public int Price { get; set; }
    }
}
