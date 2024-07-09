using DotNetCore.CAP;
using System.Text.Json;

namespace MicroService3
{
    public class RequestSuccesfulConsumer: ICapSubscribe
    {
        [CapSubscribe("place.order.mark.status")]
        public void MarkOrderStatus(JsonElement param)
        {
            var orderId = param.GetProperty("OrderId").GetInt32();
           // var isSuccess = param.GetProperty("ProducIt").GetBoolean(); 
           // var isSuccess = param.GetProperty("ProducIt").GetInt32();
            Console.WriteLine("Fallo la entrega de la orden");
            //Realiza acciones de compensacion
        }
    }
}
