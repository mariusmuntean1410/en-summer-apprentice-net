using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracticaTicketManagement.Models;
using PracticaTicketManagement.Models.Dto;
using PracticaTicketManagement.Repositories;
using System.Security.Cryptography;

namespace PracticaTicketManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public OrderController(IOrderRepository orderRepository, IMapper mapper, ILogger<EventController> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _logger = logger;
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
            try
            {
                var @order = await _orderRepository.GetByOrderId(id);

                if (@order == null)
                {
                    return NotFound();
                }



                var dtoOrder = _mapper.Map<OrderDto>(@order);


                return Ok(dtoOrder);
            }
            catch (Exception ex) {

                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatch)
        {
            if (orderPatch == null) throw new ArgumentNullException(nameof(orderPatch));
            var orderEntity = await _orderRepository.GetByOrderId(orderPatch.OrderId);
         
            if (orderPatch.NumberOfTickets != null) orderEntity.NumberOfTickets = orderPatch.NumberOfTickets;
            if (orderPatch.CustomerId != null) orderEntity.CustomerId = orderPatch.CustomerId;
            _mapper.Map(orderPatch, orderEntity);
            _orderRepository.UpdateOrder(orderEntity);
            return Ok(orderEntity);
        }

        [HttpDelete]
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
            
                
        }


    }

