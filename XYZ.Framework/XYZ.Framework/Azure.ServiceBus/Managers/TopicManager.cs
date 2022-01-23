using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XYZ.Framework.Azure.ServiceBus.Topics;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Management;
using Newtonsoft.Json;

namespace XYZ.Framework.Azure.ServiceBus.Managers
{
    public class TopicManager: ITopicManager
    {
        private IConnectionManager _connectionManager;
        public TopicManager(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public Message PrepareMessage<T>(T message) where T : Topic
        {
            string type = message.GetType().ToString();
            string[] typeSplits = type.Split('.', '+');
            string exactType = typeSplits[typeSplits.Length - 1];

            var serializedMessage = JsonConvert.SerializeObject(message);
            var messageBody = Encoding.UTF8.GetBytes(serializedMessage);

            return new Message
            {
                MessageId = Guid.NewGuid().ToString(),
                Body = messageBody,
                Label = exactType
            };
        }

        public async Task<bool> CreateTopic(string topicName)
        {
            var managementClient = new ManagementClient(_connectionManager.GetConnectionString());
            if (!await managementClient.TopicExistsAsync(topicName))
                await managementClient.CreateTopicAsync(topicName);
            return true;
        }

        public async Task<bool> CreateTopic(Message message)
        {
            var managementClient = new ManagementClient(_connectionManager.GetConnectionString());
            if (!await managementClient.TopicExistsAsync(message.Label))
                await managementClient.CreateTopicAsync(message.Label);
            return true;
        }

        public async Task<bool> SendMessageToTopic(Message message)
        {
           var topicClient = new TopicClient(_connectionManager.GetConnectionString(), message.Label);
           await topicClient.SendAsync(message);
           return true;
        }

        
    }
}
