using System;

namespace XYZ.Framework.Azure.ServiceBus.Topics
{
    public class PlaceOrderTopic : Topic
    {
        public Guid OrderId { get; set; }

        public string OrderStatus { get; set; }
    }
}
