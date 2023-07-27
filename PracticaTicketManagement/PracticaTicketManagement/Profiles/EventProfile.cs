using AutoMapper;
using PracticaTicketManagement.Models;
using PracticaTicketManagement.Models.Dto;

namespace PracticaTicketManagement.Profiles
  
{
    public class EventProfile : Profile
    {
        public EventProfile() {
            CreateMap<Event, EventDto>().ReverseMap();
      
            CreateMap<Event, EventPatchDto>().ReverseMap();
        }   
    }
}
    