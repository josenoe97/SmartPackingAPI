using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartPacking.Data;
using SmartPacking.Data.Dto;
using SmartPacking.Model;
using SmartPacking.Repository;
using SmartPacking.Repository.Interfaces;
using SmartPacking.Service;
using SmartPacking.Service.Interfaces;
using System.Threading.Tasks;

namespace SmartPacking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBoxRepository _boxRepository;

        private readonly SmartPackingContext _context;

        private readonly IOrderPackingService _orderPackingService;

        public OrderController(SmartPackingContext context, IBoxRepository boxRepository, IOrderPackingService orderPackingService)
        {
            _context = context;
            _boxRepository = boxRepository;
            _orderPackingService = orderPackingService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<OrderModel> orders)
        {
            _context.Orders.AddRange(orders);
            _context.SaveChanges();

            List<BoxModel> boxList = await _boxRepository.GetAllBoxsAsync();

            var result = _orderPackingService.ProcessOrders(orders, boxList);

            return Ok(result);
        }
    }
}
