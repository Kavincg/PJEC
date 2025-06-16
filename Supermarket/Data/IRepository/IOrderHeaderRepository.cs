using Supermarket.Models;

namespace Supermarket.Data.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader obj);
        void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId);
        // Add this method
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
    }
}