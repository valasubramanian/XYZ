using System;

namespace XYZ.Framework.Azure.ServiceBus.Topics
{
    public class OrderPlacedCommand : Topic
    {
        
        public Guid OrderId { get; set; }

        public string DeliveryStatus { get; set; }
    }
}
