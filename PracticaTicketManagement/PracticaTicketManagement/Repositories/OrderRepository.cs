using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PracticaTicketManagement.Exceptions;
using PracticaTicketManagement.Models;

namespace PracticaTicketManagement.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PracticaTicketManagementContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new PracticaTicketManagementContext();
        }

        public void CreateOrder(Order @order)
        {
            _dbContext.Add(order);
            _dbContext.SaveChanges();
        }

        public void DeleteOrder(Order @order)
        {
            _dbContext.Remove(@order);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = _dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.TicketCategory)
                .ToList();
            if (orders == null)
            {

                throw new EntityNotFoundException(nameof(Order));
            }
       

            return orders;
        }

        public async Task<Order> GetByOrderId(int id)
        {
            var @order = await _dbContext.Orders.Where(e => e.OrderId == id)
                .Include(o => o.Customer)
                .Include(o => o.TicketCategory).FirstOrDefaultAsync();
            if (@order == null)
            {

                throw new EntityNotFoundException(id, nameof(Order));
            }
            return @order;
        }

        public async Task UpdateOrder(Order @order)
        {

            _dbContext.Entry(@order).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
  