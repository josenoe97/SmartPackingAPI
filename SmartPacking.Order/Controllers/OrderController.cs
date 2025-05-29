using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartPacking.Data;
using SmartPacking.Model;
using SmartPacking.Repository;
using SmartPacking.Repository.Interfaces;
using System.Threading.Tasks;

namespace SmartPacking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBoxRepository _boxRepository;

        private readonly OrderContext _context;

        public OrderController(OrderContext context, IBoxRepository boxRepository)
        {
            _context = context;
            _boxRepository = boxRepository;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    return Ok();
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<OrderModel> orders)
        {
            List<BoxModel> boxList = await _boxRepository.GetAllBoxsAsync();

            _context.Orders.AddRange(orders);
            _context.SaveChanges();

            return Ok(orders);
        }
    }
}
