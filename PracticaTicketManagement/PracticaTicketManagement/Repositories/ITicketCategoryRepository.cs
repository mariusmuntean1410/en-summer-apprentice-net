using PracticaTicketManagement.Models;

namespace PracticaTicketManagement.Repositories
{
    public interface ITicketCategoryRepository
    {
        Task<TicketCategory> GetByOrderId(long id);
    }
}
