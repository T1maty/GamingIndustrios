using GamingIndustrios.Models;

namespace GamingIndustrios.Service.Interfaces
{
    public interface ISubscriptionService
    {
        public Subscription AdSubscription(Subscription subscription);
        public Result DeleteSubscription(int? id);
    }
}
