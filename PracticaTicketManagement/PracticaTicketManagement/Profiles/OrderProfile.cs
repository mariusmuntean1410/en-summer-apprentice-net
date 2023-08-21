using PracticaTicketManagement.Models.Dto;
using PracticaTicketManagement.Models;
using AutoMapper;

namespace PracticaTicketManagement.Profiles
{
    public class OrderProfile : Profile
    {

        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderPatchDto>().ReverseMap();
        }
    }
}
