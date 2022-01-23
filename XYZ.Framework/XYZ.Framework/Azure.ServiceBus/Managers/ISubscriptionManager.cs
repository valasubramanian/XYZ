using System;
using System.Collections.Generic;
using System.Text;
using XYZ.Framework.Azure.ServiceBus.Topics;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace XYZ.Framework.Azure.ServiceBus.Managers
{
    public interface ISubscriptionManager
    {
        Task SubscribeTopic<T, TH>() where T : Topic where TH : ITopicHandler;
        Task UnSubscribeTopic<T>() where T : Topic;
    }
}
