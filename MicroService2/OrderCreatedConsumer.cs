using DotNetCore.CAP;
using System.Text.Json;

namespace MicroService2
{
    public class OrderCreatedConsumer : ICapSubscribe
    {
        private readonly ICapPublisher _capBus;

        public OrderCreatedConsumer(ICapPublisher capBus)
        {
            _capBus = capBus;
        }

        [CapSubscribe("place.order.qty.deducted")]
        public object CheckReceivedMessage(object orderDTO)
        {
            try
            {
                throw new Exception("Fallo aqui la logica de negocio");
                //business logic
                _capBus.Publish("place.order.qty.anotherlogic",
                          contentObj: orderDTO);

            }
            catch (Exception ex)
            {
                _capBus.Publish("place.order.mark.status",
                          contentObj: orderDTO);
            }

            return new { OrderId = 1, IsSuccess = true };
        }
        [CapSubscribe("place.order.anotherlogicfail")]
        public void MarkOrderStatus(JsonElement param)
        {
            var orderId = param.GetProperty("OrderId").GetInt32();
            var isSuccess = param.GetProperty("IsSuccess").GetBoolean();

            if (isSuccess)
            {
                // mark order status to succeeded
            }
            else
            {
                // mark order status to failed
            }
        }
    }
}
