using PracticaTicketManagement.Models;

namespace PracticaTicketManagement.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();

       Task<Order> GetByOrderId(int id);

        void AddOrder(Order @order);

        void UpdateOrder(Order @order);

        void DeleteOrder(Order @order);
    }
}
