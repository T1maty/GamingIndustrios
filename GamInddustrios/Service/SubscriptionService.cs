using GamingIndustrios.DataContextClass;
using GamingIndustrios.Models;
using GamingIndustrios.Service.Interfaces;

namespace GamingIndustrios.Service
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly DataClass _dbContext;
        public Subscription AdSubscription(Subscription subscription)
        {
            var result = _dbContext.Subscriptions.Add(subscription);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        

        public Result DeleteSubscription(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new Result
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        ErrorMessage = "Id not provided"
                    };
                }
                var filteredData = _dbContext.Subscriptions.Where(x => x.Id == id).FirstOrDefault();
                if (filteredData == null)
                {
                    return new Result
                    {
                        Id = (int)id,
                        StatusCode = System.Net.HttpStatusCode.NotFound,
                        ErrorMessage = "Product id not found"
                    };
                }
                var result = _dbContext.Remove(filteredData);
                _dbContext.SaveChanges();

                return new Result
                {
                    Id = result.Entity.Id,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    CustomObject = result.Entity
                };
            }
            catch (Exception ex)
            {

                return new Result
                {
                    Id = (int)id,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
