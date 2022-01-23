using System;
using System.Collections.Generic;
using System.Text;
using XYZ.Framework.Azure.ServiceBus.Topics;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace XYZ.Framework.Azure.ServiceBus.Managers
{
    public interface ITopicManager
    {
        Message PrepareMessage<T>(T message) where T : Topic;
        Task<bool> CreateTopic(string topicName);
        Task<bool> CreateTopic(Message message);
        Task<bool> SendMessageToTopic(Message message);
    }
}
