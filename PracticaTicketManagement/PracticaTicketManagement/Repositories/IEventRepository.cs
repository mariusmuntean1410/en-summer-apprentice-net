using PracticaTicketManagement.Models;

namespace PracticaTicketManagement.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();

        Task<Event> GetById(long id);

        int Add(Event @event);

        void Update(Event @event);

        void  Delete(Event @event);
     
    }
}
