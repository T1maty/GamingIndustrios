using System.Net;

namespace GamingIndustrios.Models
{
    public class Result
    {
        public int Id { get; set; }
        public HttpStatusCode statusCode { get; init; }
        public HttpStatusCode StatusCode { get; internal set; }
        public string ErrorMessage { get; init; }    
        public object?  CustomObject { get; init; }  
    }
}
