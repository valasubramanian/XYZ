using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XYZ.Framework.Azure.ServiceBus.Managers;
using XYZ.Framework.Azure.ServiceBus.Topics;
using Microsoft.Azure.ServiceBus;

namespace XYZ.Framework.Azure.ServiceBus
{
    public class Publisher: IPublisher
    {
        private ITopicManager _topicManager;
        public Publisher(ITopicManager topicManager)
        {
            _topicManager = topicManager;
        }

        public async Task Publish<T>(T message) where T : Topic
        {
            Message topicMessage = _topicManager.PrepareMessage(message);
            bool topicCreated = await _topicManager.CreateTopic(topicMessage);
            if(topicCreated)
                await _topicManager.SendMessageToTopic(topicMessage);
        }
    }
}
