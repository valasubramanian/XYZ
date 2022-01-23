using System;
using System.Collections.Generic;
using System.Text;

namespace XYZ.Framework.Azure.ServiceBus.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
