using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartPacking.Model;

namespace SmartPacking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //private readonly EmpacotadorService _service;

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
        public IActionResult Post([FromBody] List<OrderModel> pedidos)
        {
            //var resultado = pedidos.Select(p => new {
            //    PedidoId = p.Id,
            //    Caixas = _service.ProcessarPedido(p)
            //});

            return Ok(/*resultado*/);
        }
    }
}
