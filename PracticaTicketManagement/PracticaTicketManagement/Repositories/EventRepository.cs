using PracticaTicketManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PracticaTicketManagement.Exceptions;

namespace PracticaTicketManagement.Repositories
{

    public class EventRepository : IEventRepository
    {
        private readonly PracticaTicketManagementContext _dbContext;

        public EventRepository()
        {
            _dbContext = new PracticaTicketManagementContext();
        }

        public int Add(Event @event)
        {
            throw new NotImplementedException();
        }

        public void Delete(Event @event)
        {
            _dbContext.Remove(@event);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events
                .Include(e=>e.EventType)
                .Include(e => e.Venue)
                .ToList();

            if (events == null)
            {

                throw new EntityNotFoundException(nameof(Event));
            }
           
            return events;
        }

        public async Task<Event> GetById(long id)
        {




            var @event = await _dbContext.Events.Where(e => e.EventId == id)
                .Include(e => e.EventType)
                .Include(e => e.Venue)
            .FirstOrDefaultAsync();

            if (@event == null)
            {

                throw new EntityNotFoundException(id, nameof(Event));
            }
            return @event;
        }
    

        public void Update(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;
               _dbContext.SaveChanges();
        }
    }

}

