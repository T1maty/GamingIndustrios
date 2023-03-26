namespace GamingIndustrios.Models
{
    public class Customer:BaseObject
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int  PhoneNumber { get; set; }
        public string Separation { get; set; }
        public int BrunchNumber { get; set; }
        public DateTime CreatedDate { get; set; }
         
    }
}
