using PracticaTicketManagement.Models;

namespace PracticaTicketManagement.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();

       Task<Order> GetByOrderId(int id);

        void CreateOrder(Order @order);

        Task UpdateOrder(Order @order);

        void DeleteOrder(Order @order);
    }
}
