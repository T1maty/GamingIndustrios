using GamingIndustrios.Models;

namespace GamingIndustrios.Service.Interfaces
{
    public interface IComputerService
    {
        public  Computer AddComputer(Computer computer);
        public Computer DeleteComputer (Computer computer);
    }
}
