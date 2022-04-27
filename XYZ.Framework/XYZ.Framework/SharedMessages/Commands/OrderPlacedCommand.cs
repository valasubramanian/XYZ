using System;

namespace XYZ.Framework.Azure.ServiceBus.Topics
{
    public class DeliveryStatusTopic : Topic
    {
        
        public Guid OrderId { get; set; }

        public string DeliveryStatus { get; set; }
    }
}
