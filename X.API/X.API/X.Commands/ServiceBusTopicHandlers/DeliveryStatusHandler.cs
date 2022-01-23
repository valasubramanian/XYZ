using System;
using System.Threading.Tasks;
using XYZ.Framework.Azure.ServiceBus.Topics;

namespace X.Service.ServiceBusTopicHandlers
{
    public class DeliveryStatusHandler : ITopicHandler<DeliveryStatusTopic>
    {
        public DeliveryStatusHandler()
        {

        }

        // { "serviceBusTopicId":"1f835d4e-4d20-4cb0-b724-a21b3fff4d22", "serviceBusTopicCreatedOn": "2017-09-08T19:01:55.714942+03:00", "orderId":"0f835d4e-4d20-4cb0-b724-a21b3fff4d22", "deliveryStatus":"NEW"}
        public Task Handle(DeliveryStatusTopic message)
        {
            return Task.CompletedTask;
        }
    }
}
