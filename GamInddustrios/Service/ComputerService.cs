using GamingIndustrios.DataContextClass;
using GamingIndustrios.Models;
using GamingIndustrios.Service.Interfaces;

namespace GamingIndustrios.Service
{
    public class ComputerService : IComputerService
    {
        private readonly DataClass _dbContext;
        public ComputerService(DataClass dbContext)
        {
            _dbContext = dbContext;
        }

        public Computer AddComputer(Computer computer)
        {
            var result  = _dbContext.Computers.Add(computer);    
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public Computer DeleteComputer(Computer computer)
        {
            throw new NotImplementedException();
        }
    }
}
