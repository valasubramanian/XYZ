using System;
using System.Collections.Generic;
using System.Text;

namespace XYZ.Framework.Azure.ServiceBus.Models
{
    public abstract class ServiceBusMessage
    {
        public ServiceBusMessage()
        {
            ServiceBusMessageId = Guid.NewGuid();
            ServiceBusMessageCreatedOn = DateTime.Now;
        }

        public Guid ServiceBusMessageId { get; set; }
        public DateTime ServiceBusMessageCreatedOn { get; set; }
        public string ServiceBusMessageTopic { get; set; }
    }
}
