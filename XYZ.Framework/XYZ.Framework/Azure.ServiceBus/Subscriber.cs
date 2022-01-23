using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XYZ.Framework.Azure.ServiceBus.Managers;
using XYZ.Framework.Azure.ServiceBus.Topics;
using Microsoft.Azure.ServiceBus;

namespace XYZ.Framework.Azure.ServiceBus
{
    public class Subscriber : ISubscriber
    {
        private ISubscriptionManager _subscriptionManager;
        public Subscriber(ISubscriptionManager subscriptionManager)
        {
            _subscriptionManager = subscriptionManager;
        }

        public async Task Subscribe<T>(T topic) where T : Topic
        {
            //await _subscriptionManager.SubscribeTopic(topic);
        }
    }
}
