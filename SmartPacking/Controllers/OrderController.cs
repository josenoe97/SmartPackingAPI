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
        //private readonly EmpacotadorService _service;

        private readonly IBoxRepository _boxRepository;

        private readonly SmartPackingContext _context;

        public OrderController(SmartPackingContext context, IBoxRepository boxRepository)
        {
            _context = context;
            _boxRepository = boxRepository;
        }

        //public OrderController(EmpacotadorService service)
        //{
        //    _service = service;
        //}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<OrderModel> orders)
        {
            List<BoxModel> boxList = await _boxRepository.GetAllBoxsAsync();

            //var resultado = pedidos.Select(p => new {
            //    PedidoId = p.Id,
            //    Caixas = _service.ProcessarPedido(p)
            //});



            return Ok(boxList); // Retorna a lista para o frontend
        }
    }
}
