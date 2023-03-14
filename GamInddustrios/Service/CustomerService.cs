using GamingIndustrios.DataContextClass;
using GamingIndustrios.Models;
using GamingIndustrios.Service.Interfaces;

namespace GamingIndustrios.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly DataClass _dbContext;
        public CustomerService(DataClass dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer AddCustomer(Customer customer)
        {
             var result = _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
