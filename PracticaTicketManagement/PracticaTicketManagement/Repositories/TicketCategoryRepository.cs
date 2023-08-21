using Microsoft.EntityFrameworkCore;
using PracticaTicketManagement.Exceptions;
using PracticaTicketManagement.Models;

namespace PracticaTicketManagement.Repositories
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly PracticaTicketManagementContext _dbContext;
        public TicketCategoryRepository()
        {
            _dbContext = new PracticaTicketManagementContext();
        }

        public int Add(TicketCategory ticketCategory)
        {
            throw new NotImplementedException();
        }

        public void Delete(TicketCategory ticketCategory)
        {
            throw new NotImplementedException();
        }

       

        public async Task<TicketCategory> GetByOrderId(long id)
        {
            var @ticketCategories = await _dbContext.TicketCategories.Where(e => e.TicketCategoryId == id).FirstOrDefaultAsync();
            if (ticketCategories == null)
            {
                throw new EntityNotFoundException(id, nameof(TicketCategory));
            }
            return ticketCategories;
        }

        public bool TicketCategoryExists(long ticketCategoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(TicketCategory ticketCategory)
        {
            throw new NotImplementedException();
        }
    }
}

