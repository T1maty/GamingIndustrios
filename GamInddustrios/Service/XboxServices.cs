using GamingIndustrios.Models;
using GamingIndustrios.Service.Interfaces;
using GamingIndustrios.DataContextClass;
namespace GamingIndustrios.Service
{
    public class XboxServices : IXboxServices
    {
        private readonly DataClass _dbContext;

        public XboxServices(DataClass dataContext)
        {
            _dbContext = dataContext;
        }

        public Xbox AddXbox(Xbox xbox)
        {
            var result = _dbContext.Xboxes.Add(xbox);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
