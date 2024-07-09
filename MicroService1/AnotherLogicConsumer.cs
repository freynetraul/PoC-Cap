using DotNetCore.CAP;

namespace MicroService1
{
    public class AnotherLogicConsumer : ICapSubscribe
    {
        public readonly ICapPublisher _capBus;

        public AnotherLogicConsumer(ICapPublisher capBus)
        {
            _capBus = capBus;
        }

        [CapSubscribe("place.order.qty.deducted")]
        public object CheckReceivedMessage(object orderDTO)
        {
            try
            {
                //business logic
                _capBus.Publish("place.order.mark.status",
                          contentObj: orderDTO);

            }
            catch (Exception ex)
            {
                _capBus.Publish("place.order.anotherlogicfail",
                          contentObj: orderDTO);
            }

            return new { OrderId = 1, IsSuccess = true };
        }
    }
}
