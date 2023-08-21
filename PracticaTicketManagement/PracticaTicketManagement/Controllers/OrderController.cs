using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracticaTicketManagement.Models;
using PracticaTicketManagement.Models.Dto;
using PracticaTicketManagement.Repositories;
using System.Security.Cryptography;
using System.Text.Json;

namespace PracticaTicketManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
         private readonly ITicketCategoryRepository _ticketCategoryRepository;
      
        private readonly IMapper _mapper;
     /*   private readonly ILogger _logger;*/

        public OrderController(IOrderRepository orderRepository, IMapper mapper/*, ILogger<EventController> logger ,ICustomerRepository customerRepository*/, ITicketCategoryRepository ticketCategoryRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
          /*  _logger = logger;
            _customerRepository = customerRepository;*/
            _ticketCategoryRepository = ticketCategoryRepository;
        }

        [HttpGet()]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var orders = _orderRepository.GetAllOrders();



            var dtoOrders = orders.Select(o => _mapper.Map<OrderDto>(o)).ToList();



            return Ok(dtoOrders);
        }

        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetByOrderId(int id)
        {
            
                var @order = await _orderRepository.GetByOrderId(id);

                if (@order == null)
                {
                    return NotFound();
                }



                var dtoOrder = _mapper.Map<OrderDto>(@order);


                return Ok(dtoOrder);
            }



        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatch)
        {
            var orderEntity = await _orderRepository.GetByOrderId(orderPatch.OrderId);
            var ticketCategoryEntity = await _ticketCategoryRepository.GetByOrderId(orderPatch.TicketCategoryId);

            if (orderEntity == null)
            {
                return NotFound();
            }

            orderEntity.TotalPrice = orderPatch.NumberOfTickets * ticketCategoryEntity.Price;
            _mapper.Map(orderPatch, orderEntity);
            await _orderRepository.UpdateOrder(orderEntity);

            var orderResponse = _mapper.Map<OrderDto>(orderEntity);

            return new ContentResult()
            {
                Content = JsonSerializer.Serialize(orderResponse),
                ContentType = "application/json",
                StatusCode = StatusCodes.Status200OK
            };
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var orderEntity = await _orderRepository.GetByOrderId(id);

            if (orderEntity == null)
            {
                return NotFound();
            }

            _orderRepository.DeleteOrder(orderEntity);
            return NoContent();
        }



/*
        [HttpPost]
        public async Task<ActionResult> CreateOrder(OrderCreateDto newOrder)
        {

            var customer = await _customerRepository.GetById(1);

            if (customer == null)
            {
                return BadRequest("Customer not found.");
            }


            var numberOfTickets = newOrder.NumberOfTickets;
            var date = DateTime.Now;
            var totalPrice = numberOfTickets * ticketCategory.Price;


            var @order = new Order
            {
                CustomerId = customer.CustomerId,
                TicketCategoryId = ticketCategory.TicketCategoryId,
                OrderedAt = date,
                NumberOfTickets = numberOfTickets,
                TotalPrice = totalPrice
            };


            @order = await _orderRepository.Add(Order);
            if (@order == null) return BadRequest("Order not created");
            return _mapper.Map<OrderDto>(@order);



        }*/
    }
}