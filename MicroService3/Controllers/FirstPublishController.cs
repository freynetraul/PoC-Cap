using DotNetCore.CAP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MicroService3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstPublishController : ControllerBase
    {
        public readonly ICapPublisher _capBus;
        public FirstPublishController(ICapPublisher capBus)
        {
            _capBus = capBus;
        }



        [HttpPost]
        public void GenerarOrden([FromBody] OrderDTO orderDTO)
        {
            _capBus.Publish("place.order.qty.deducted",
             contentObj: orderDTO);
        }




    }

    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int ProducIt { get; set; }

        public int Qty { get; set; }
    }
}
